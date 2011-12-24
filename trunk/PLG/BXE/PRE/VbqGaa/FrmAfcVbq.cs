using System;
using System.Data;
using System.Windows.Forms;

namespace BXE.PRE.VbqGaa
{
    public partial class FrmAfcVbq : Form, UTL.PLG.ItfPlg
    {
        #region Contansts
        const string STR_MENU = "Cổng &vào";
        private const string STR_DESC = "In gate form";
        private const string STR_DMY = "dd/MM/yyyy HH:mm:ss";

        private const string STR_IN_GATE = "Xe này đang ở trong bến!";
        private const string STR_IN_MAG = "Xe này đã có trong danh sách quản lí!";

        private const string STR_INP_ERR = "Lỗi, nhập dữ liệu sai{0}{1}";
        private const string STR_INP_HAD = "&Nhập bằng tay";
        private const string STR_ADD_SUC = "Đã cho xe vào!";
        private const string STR_EDI_SUC = "Sửa thành công!";

        private const string STR_DEL_SUC = "Xoá thành công!";
        private const string STR_DEL_ERR = "Lỗi xoá dữ liệu!";

        private const string STR_NO_SAVE = "Không thêm được!";
        private const string STR_NOT_EDIT = "Không sửa được!";
        private const string STR_NOT_DEL = "Không xoá được!";
        private const string STR_NOT_NUM = "Biển số không hợp lệ hợp lệ!";
        private const string STR_NOT_INP = "Chưa nhập biển số!";

        private const string STR_NOT_W = "Tải trọng không hợp lệ!";
        private const string STR_NOT_L = "Chiều dài không hợp lệ!";
        private const string STR_NOT_C = "Số ghế không hợp lệ!";
        #endregion

        #region Default objects
        public UTL.BLL.UecLajVei _sss = new UTL.BLL.UecLajVei();
        #endregion

        #region More objects
        private readonly DAL.DetailDAL _dal = new DAL.DetailDAL();

        static int _sec; // current second
        private int _row; // current row index
        private decimal _wMin, _wMax; // weight
        private int _cMin, _cMax; // chair
        private decimal _lMin, _lMax; // length

        private DAL.Vehicle _obj = new DAL.Vehicle();
        private int _pagIndex;
        #endregion

        #region Properties
        public string EditNumber { set; get; } // number need to update from form gate out
        public bool EditMode { set; get; } // edit mode allow edit mode in this form or another form
        public bool EditHand { set; get; } // edit by hand
        #endregion

        #region Implement
        string UTL.PLG.ItfPlg.Name { get { return STR_MENU; } }
        string UTL.PLG.ItfPlg.Description { get { return STR_DESC; } }
        string UTL.PLG.ItfPlg.Author { get { return "Zng Tfy"; } }
        string UTL.PLG.ItfPlg.Version { get { return "1.0"; } }

        UserControl UTL.PLG.ItfPlg.Usrcontrol { get { return null; } }
        Form UTL.PLG.ItfPlg.Frmcontrol { get { return this; } }
        UTL.PLG.ItfHst UTL.PLG.ItfPlg.Host { get; set; }

        public UTL.BLL.UecLajVei Sss { get { return _sss; } set { _sss = value; } }
        public UTL.CsoInf Inf { get; set; }

        void UTL.PLG.ItfPlg.Initialize() { }
        void UTL.PLG.ItfPlg.Dispose() { }
        #endregion

        #region Constructors
        public FrmAfcVbq()
        {
            InitializeComponent();

            EditMode = true; // allow edit mode in this form (not call by another form)
            EditHand = false; // not allow to edit by hand
        }
        #endregion

        #region Events
        private void cmdClose_Click(object sender, EventArgs e) { Close(); }

        private void FrmAfcVbq_Load(object sender, EventArgs e)
        {
            lblAccInName.Text = Sss.Name.ToUpper(); // get full name user gate in
            tmrDongHo_Tick(sender, e); tmrDongHo.Enabled = true; // run timer            

            GetInMinute(); ClearText();

            if (EditMode)
            {
                EditNumber = null;
            }
            else
            {
                if (CheckExistsNumber(EditNumber))
                {
                    cmdEdit.Enabled = true;
                    cmdIn.Enabled = false;
                }
                else
                {
                    cmdEdit.Enabled = false;
                    cmdIn.Enabled = true;
                    EditNumber = null;
                }
            }

            if (EditHand)
            {
                dtpDateIn.Visible = true;
                dtpDateIn.Location = lblDateIn.Location;
                lblDateIn.Visible = false;
                tmrDongHo.Enabled = false;
                _sss.Current = dtpDateIn.Value;
            }
            else
            {
                dtpDateIn.Visible = false;
                lblDateIn.Visible = true;
                tmrDongHo.Enabled = true;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (ValidNumber())
            {
                int chair;
                decimal length, weight;
                if (!ConvertText(out chair, out length, out weight)) return; // fail to exit

                var o = new DAL.Vehicle()
                {
                    //Number = _obj.Number,
                    //KindId = Convert.ToInt64(cbbKind.SelectedValue),
                    Chair = chair,
                    Length = length,
                    Weight = weight
                };

                if (_dal.UpdateNumber(EditNumber, o))
                {
                    UTL.CsoUTL.Show(STR_EDI_SUC);
                    GetInMinute();
                    cmdIn.Enabled = true;
                    cmdDelete.Enabled = false;
                    cmdEdit.Enabled = false;
                    EditNumber = null;

                    if (!EditMode) Close();
                }
                else UTL.CsoUTL.Show(STR_NOT_EDIT);

            }
        }

        private void dgvAep_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Stt();
        }

        private void cmdIn_Click(object sender, EventArgs e)
        {
            GetCurrObj(_pagIndex);

            if (!ValidNumber()) return;

            if (_pagIndex == 2)
            {
                if (!ValidWeight()) return;
                if (!ValidLenght()) return;
            }

            if (_pagIndex == 4) if (!ValidChair()) return;

            int chair;
            decimal length, weight;
            if (!ConvertText(out chair, out length, out weight)) return; // fail to exit

            object detail;
            var ktr = new DAL.VehicleDAL();

            if (ktr.CheckExist(_obj.Number)) // kiểm tra biển số xe trong danh sách các xe được quản lí
            {
                var o = new DAL.Detail()
                {
                    AccIn = _sss.Id,
                    Number = _obj.Number,
                    DateIn = _sss.Current
                };

                detail = (object)o;

                if (detail != null)
                {
                    if (_dal.Insert(detail))
                    {
                        ClearText();
                        lblInf.Text = STR_ADD_SUC;
                    }
                    else UTL.CsoUTL.Show(STR_IN_GATE);
                }
            }
            else
            {
                try
                {
                    var ve = new DAL.Vehicle
                    {
                        Number = _obj.Number,
                        KindId = _obj.KindId,
                        Chair = chair,
                        Length = length,
                        Weight = weight
                    };

                    object v = (object)ve;

                    if (ktr.Insert(v)) // thêm biển số xe nào vào danh sách quản lí
                    {
                        v = new DAL.Detail()
                        {
                            AccIn = _sss.Id,
                            Number = _obj.Number,
                            DateIn = _sss.Current
                        };

                        detail = (object)v;

                        if (detail != null)
                        {
                            if (_dal.Insert(detail))
                            {
                                ClearText();
                                lblInf.Text = STR_ADD_SUC;
                            }
                            else UTL.CsoUTL.Show(STR_NO_SAVE);
                        }
                    }
                    else lblInf.Text = STR_IN_MAG;
                }
                catch (Exception ex)
                {
                    UTL.CsoUTL.Show(String.Format(STR_INP_ERR, Environment.NewLine, ex.Message));
                }
            }

            GetInMinute(); // load list vehicles in a minute            
        }

        private void mskNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _obj.Number = _obj.Number.ToUpper();

            if (CheckExistsNumber())
            {
                lblInf.Text = STR_IN_MAG;
                ShowDetail(_obj.Number);
            }
            else lblInf.Text = null;
        }

        private void cbbKind_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tmrDongHo_Tick(object sender, EventArgs e)
        {
            _sec++;
            if (_sec >= 60)
            {
                GetInMinute();
                _sec = 0;
            }
            if (_sss.Current != null) lblDateIn.Text = _sss.Current.Value.ToString(STR_DMY);
        }

        private void cmdRefresh_Click(object sender, EventArgs e) { GetInMinute(); }

        private void cbbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //// Load list vehicles
            //var grp = cbbGroup.SelectedValue;
            //var dal = new DAL.KindDAL();
            //cbbKind.DataSource = dal.GetData(grp);

            //switch (grp + "")
            //{
            //    case "1":
            //        mskWeight.Enabled = true;
            //        mskLength.Enabled = true;
            //        mskChair.Enabled = false;
            //        mskChair.Text = null;
            //        break;

            //    case "2":
            //        mskLength.Enabled = false;
            //        mskWeight.Enabled = false;
            //        mskWeight.Text = null;
            //        mskChair.Enabled = true;
            //        break;

            //    case "4":
            //        mskWeight.Enabled = false;
            //        mskLength.Enabled = false;
            //        mskChair.Enabled = false;
            //        break;

            //    case "5":
            //        mskLength.Enabled = false;
            //        mskWeight.Enabled = false;
            //        mskWeight.Text = null;
            //        mskChair.Enabled = true;
            //        break;

            //    default:
            //        mskLength.Enabled = false;
            //        mskWeight.Enabled = false;
            //        mskWeight.Text = null;
            //        mskChair.Enabled = false;
            //        mskChair.Text = null;
            //        break;
            //}
        }

        private void dgvAep_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            return;
            //using (var sf = new StringFormat { Alignment = StringAlignment.Center })
            //{
            //    if (e.ColumnIndex < 0 && e.RowIndex >= 0 && e.RowIndex < dgvAep.Rows.Count)
            //    {
            //        using (var drawBrush = new SolidBrush(Color.Black))
            //        {
            //            e.Graphics.DrawString((e.RowIndex + 1).ToString(), Font, drawBrush, e.CellBounds, sf);
            //        }
            //        e.Handled = true;
            //    }
            //}
        }

        private void dgvAep_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                object id = e.Row.Cells["colId"].Value;
                id = id + "" == "" ? -1 : id;

                if (_dal.Delete(new DAL.Detail() { Id = Convert.ToInt64(id) }))
                    UTL.CsoUTL.Show(STR_DEL_SUC);
                else
                {
                    UTL.CsoUTL.Show(STR_NOT_DEL);
                    e.Cancel = true;
                }
            }
            catch
            {
                UTL.CsoUTL.Show(STR_DEL_ERR);
                e.Cancel = true;
            }
        }

        private void cmdInList_Click(object sender, EventArgs e)
        {
            using (var x = new YhwCcn.FrmAhvBdd())
            {
                x.ShowDialog();
            }
        }

        private void dgvAep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _row = e.RowIndex;
            string num = dgvAep.Rows[_row].Cells["colNumber"].Value.ToString();

            if (CheckExistsNumber(num))
            {
                cmdEdit.Enabled = true;
                cmdDelete.Enabled = true;
                cmdIn.Enabled = false;
                EditNumber = num;
            }
            else
            {
                cmdEdit.Enabled = false;
                cmdDelete.Enabled = false;
                cmdIn.Enabled = true;
                EditNumber = null;
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            var dal = new DAL.DetailDAL();
            if (dal.DeleteByNumber(_obj.Number))
            {
                lblInf.Text = STR_DEL_SUC;
                if (_row >= 0) dgvAep.Rows.RemoveAt(_row);
                cmdIn.Enabled = true;
                cmdEdit.Enabled = false;
                cmdDelete.Enabled = false;
            }
            else
                UTL.CsoUTL.Show(STR_NOT_DEL);
        }
        #endregion

        #region Methods
        private bool ConvertText(out int chair, out decimal length, out decimal weight)
        {
            string m1 = mskMediumC.Text.Trim();
            string m2 = mskTruckL.Text.Trim();
            string m3 = mskTruckW.Text.Trim();

            if (m1 == "") m1 = "0";
            if (m2 == "") m2 = "0";
            if (m3 == "") m3 = "0";

            var ok1 = Int32.TryParse(m1, out chair);
            var ok2 = Decimal.TryParse(m2, out length);
            var ok3 = Decimal.TryParse(m3, out weight);

            return ok1 && ok2 && ok3;
        }

        private bool ValidChair()
        {
            var oki = UTL.SFI.CsoSFI.CheckNumber(mskMediumC.Text, _cMin, _cMax);
            if (!oki) UTL.CsoUTL.Show(STR_NOT_C);
            return oki;
        }

        private bool ValidLenght()
        {
            var oki = UTL.SFI.CsoSFI.CheckNumber(mskTruckL.Text, _lMin, _lMax);
            if (!oki) UTL.CsoUTL.Show(STR_NOT_L);
            return oki;
        }

        private bool ValidWeight()
        {
            var oki = UTL.SFI.CsoSFI.CheckNumber(mskTruckW.Text, _wMin, _wMax);
            if (!oki) UTL.CsoUTL.Show(STR_NOT_W);
            return oki;
        }

        private bool ValidNumber()
        {
            var oki = _obj.Number.Length == 0 ? false : true;
            if (!oki) UTL.CsoUTL.Show(STR_NOT_INP);
            else
            {
                // Check format number
                if (_obj.Number.Length > 2)
                {
                    int num;
                    string tmp = _obj.Number.Substring(0, 2);
                    oki = oki && Int32.TryParse(tmp, out num);

                    tmp = _obj.Number.Substring(2, 1);
                    oki = oki && !Int32.TryParse(tmp, out num);
                }

                if (!oki) UTL.CsoUTL.Show(STR_NOT_NUM);
            }

            return oki;
        }

        private bool ShowDetail(string number)
        {
            var oki = false;

            try
            {
                object o = (object)new DAL.Detail() { Number = number };
                var tb = _dal.Search(o);

                if (tb.Rows.Count > 0)
                {
                    DateTime timeIn = Convert.ToDateTime(tb.Rows[0]["DateIn"]);
                    lblDateIn.Text = timeIn.ToString(STR_DMY);

                    int chair = tb.Rows[0]["Chair"] + "" != "" ? Convert.ToInt32(tb.Rows[0]["Chair"]) : 0;
                    int length = tb.Rows[0]["Chair"] + "" != "" ? Convert.ToInt32(tb.Rows[0]["Length"]) : 0;
                    double weight = tb.Rows[0]["Weight"] + "" != "" ? Convert.ToInt32(tb.Rows[0]["Weight"]) : 0;

                    //cbbGroup.SelectedValue = tb.Rows[0]["GroupId"].ToString();
                    //cbbKind.SelectedValue = tb.Rows[0]["KindId"].ToString();

                    string kindId = tb.Rows[0]["KindId"].ToString();
                    if (kindId + "" != "")
                    {

                    }

                    mskTruckW.Text = weight.ToString();
                    mskMediumC.Text = chair.ToString();
                    mskTruckL.Text = length.ToString();

                    //_obj.Number = tb.Rows[0]["Number"].ToString();
                    lblAccInName.Text = tb.Rows[0]["AccIn"].ToString().ToUpper();

                    switch (_pagIndex)
                    {
                        case 0: // group 1 taxi
                            mskTaxiNumber.Text = number;
                            _obj.KindId = 10;
                            break;

                        case 1: // group 2 three circle
                            mskThreeNumber.Text = number;
                            _obj.KindId = 11;
                            break;

                        case 2: // group 3 truck
                            mskTruckNumber.Text = number;
                            _obj.KindId = Convert.ToInt64(kindId);
                            break;

                        case 3: // group 4 car
                            mskCarNumber.Text = number;
                            _obj.KindId = Convert.ToInt64(kindId);
                            break;

                        case 4: // group 5 medium
                            mskMediumNumber.Text = number;
                            _obj.KindId = 12;

                            break;

                        default:
                            break;
                    }

                    oki = true;
                }
                return oki;
            }
            catch { return oki; }
        }

        private bool CheckExistsNumber(string number = null)
        {
            string num = number ?? _obj.Number;
            var ktr = new DAL.VehicleDAL();
            var oki = ktr.CheckExist(num);
            if (oki) ShowDetail(num); // get information
            return oki;
        }

        private void ClearText()
        {
            mskTaxiNumber.Text = null;
            mskThreeNumber.Text = null;
            mskTruckNumber.Text = null;
            mskTruckL.Text = null;
            mskTruckW.Text = null;
            mskCarNumber.Text = null;
            mskMediumNumber.Text = null;
            mskMediumC.Text = null;
            lblInf.Text = null;
        }

        private void GetInMinute()
        {
            var tb = _dal.GetDataInMinute();
            if (tb.Rows.Count > 0) dgvAep.DataSource = tb;
            else
                for (int i = 0; i < dgvAep.Rows.Count; i++)
                    dgvAep.Rows.RemoveAt(i);
        }

        private void Stt()
        {
            for (int i = 0; i < dgvAep.Rows.Count; i++)
                dgvAep.Rows[i].Cells["colNo_"].Value = i + 1;
        }

        private void GetCurrObj(int index)
        {
            if (EditHand) _sss.Current = dtpDateIn.Value;

            switch (index)
            {
                case 0: // group 1 taxi
                    _obj.Number = mskTaxiNumber.Text;
                    _obj.KindId = 10;
                    break;

                case 1: // group 2 three circle
                    _obj.Number = mskThreeNumber.Text;
                    _obj.KindId = 11;
                    break;

                case 2: // group 3 truck
                    _obj.Number = mskTruckNumber.Text;
                    _obj.KindId = Convert.ToInt64(cbbTruckKind.SelectedValue);

                    string m1 = mskTruckW.Text.Trim();
                    string m2 = mskTruckL.Text.Trim();
                    if (m1 == "") m1 = "0";
                    if (m2 == "") m2 = "0";

                    decimal w, l;
                    Decimal.TryParse(m1, out w);
                    Decimal.TryParse(m2, out l);

                    _obj.Weight = w;
                    _obj.Weight = l;
                    break;

                case 3: // group 4 car
                    _obj.Number = mskCarNumber.Text;
                    _obj.KindId = Convert.ToInt64(cbbCarKind.SelectedValue);
                    break;

                case 4: // group 5 medium
                    _obj.Number = mskMediumNumber.Text;
                    _obj.KindId = 12;
                    m1 = mskMediumC.Text.Trim();
                    if (m1 == "") m1 = "0";

                    int c;
                    Int32.TryParse(m1, out c);
                    _obj.Chair = c;

                    break;

                default:
                    break;
            }
        }

        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var dal = new DAL.KindDAL();
                _pagIndex = tabControl1.SelectedIndex;

                switch (tabControl1.SelectedIndex)
                {
                    case 0: // group 1

                        break;

                    case 1: // group 2
                        break;

                    case 2: // group 3
                        cbbTruckKind.DataSource = dal.GetData(1);
                        break;

                    case 3: // group 4
                        cbbCarKind.DataSource = dal.GetData(2);
                        break;

                    case 4: // group 5
                        break;

                    default:
                        break;
                }
            }
            catch { return; }
        }

        private void cmdHand_Click(object sender, EventArgs e)
        {
            if (cmdHand.Text == STR_INP_HAD)
            {
                cmdHand.Text = "Nhậ&p tự động";
                EditHand = true;
            }
            else
            {
                cmdHand.Text = STR_INP_HAD;
                EditHand = false;
            }

            FrmAfcVbq_Load(sender, e);
        }

        private void cbbTruckKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dtb = (DataTable)cbbTruckKind.DataSource;
            DataRow[] dr = dtb.Select(string.Format("Id='{0}'", 1));

            if (dr.Length > 0)
            {
                string a1 = dr[0]["WeightMin"] + "";
                string a2 = dr[0]["WeightMax"] + "";
                //string b1 = dr[0]["ChairMin"] + "";
                //string b2 = dr[0]["ChairMax"] + "";
                string c1 = dr[0]["LengthMin"] + "";
                string c2 = dr[0]["LengthMax"] + "";

                _wMin = a1 == "" ? 0 : Convert.ToDecimal(a1);
                _wMax = a2 == "" ? 0 : Convert.ToDecimal(a2);
                //_cMin = b1 == "" ? 0 : Convert.ToInt32(b1);
                //_cMax = b2 == "" ? 0 : Convert.ToInt32(b2);
                _lMin = c1 == "" ? 0 : Convert.ToDecimal(c1);
                _lMax = c2 == "" ? 0 : Convert.ToDecimal(c2);
            }
        }

        private void cbbCarKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dtb = (DataTable)cbbCarKind.DataSource;
            DataRow[] dr = dtb.Select(string.Format("Id='{0}'", 2));

            if (dr.Length > 0)
            {
                //string a1 = dr[0]["WeightMin"] + "";
                //string a2 = dr[0]["WeightMax"] + "";
                string b1 = dr[0]["ChairMin"] + "";
                string b2 = dr[0]["ChairMax"] + "";
                //string c1 = dr[0]["LengthMin"] + "";
                //string c2 = dr[0]["LengthMax"] + "";

                //_wMin = a1 == "" ? 0 : Convert.ToDecimal(a1);
                //_wMax = a2 == "" ? 0 : Convert.ToDecimal(a2);
                _cMin = b1 == "" ? 0 : Convert.ToInt32(b1);
                _cMax = b2 == "" ? 0 : Convert.ToInt32(b2);
                //_lMin = c1 == "" ? 0 : Convert.ToDecimal(c1);
                //_lMax = c2 == "" ? 0 : Convert.ToDecimal(c2);
            }
        }

        #region More
        #endregion
    }
}