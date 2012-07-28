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
        private const string STR_ADD_SUC = "";// "Đã cho xe vào!";
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

        private DAL.Vehicle _currVehicle = new DAL.Vehicle();
        private int _currTabPageIndex;
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
        private void cmdSumary_Click(object sender, EventArgs e)
        {
            using (var x = new PRE.YhwCcn.FrmTkeVbq())
            {
                x._sss = _sss;
                x.ShowDialog();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e) { Close(); }

        private void dgvAep_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //cmdIn.Enabled = true;
            //cmdEdit.Enabled = false;
            //cmdDelete.Enabled = false;
            //ClearText();
        }

        private void FrmAfcVbq_Load(object sender, EventArgs e)
        {
            lblAccInName.Text = Sss.Name.ToUpper(); // get full name user gate in
            tabControl1_SelectedIndexChanged(null, null);
            tabControl1.TabPages.Remove(tabPage4);

            _sss.Current = _dal.CurrentTime();
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
                dtpDateIn.Top += (41 - 26) / 2;
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

        #region Valid number
        private void mskTaxiNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mskTaxiNumber.Text = ValidNumber(mskTaxiNumber.Text);
        }

        private void mskThreeNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mskThreeNumber.Text = ValidNumber(mskThreeNumber.Text);
        }

        private void mskTruckNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mskTruckNumber.Text = ValidNumber(mskTruckNumber.Text);
        }

        private void mskCarNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mskCarNumber.Text = ValidNumber(mskCarNumber.Text);
        }

        private void mskMediumNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mskMediumNumber.Text = ValidNumber(mskMediumNumber.Text);
        }
        #endregion

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (_num == null) return;

            if (cmdEdit.Text == "&Sửa")
            {
                if (CheckExistsNumber(_num))
                {
                    cmdEdit.Enabled = true;
                    cmdDelete.Enabled = true;
                    //cmdIn.Enabled = false;
                    EditNumber = _num;
                }
                else
                {
                    cmdEdit.Enabled = false;
                    cmdDelete.Enabled = false;
                    //cmdIn.Enabled = true;
                    EditNumber = null;
                }

                cmdEdit.Text = "&Lưu";
            }
            else
            {
                GetCurrObj(_currTabPageIndex);

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

                    switch (_currTabPageIndex)
                    {
                        case 1: // group 1 taxi                        
                            o.Number = mskTaxiNumber.Text;
                            o.KindId = 10;
                            break;

                        case 2: // group 2 three circle                        
                            o.Number = mskThreeNumber.Text;
                            o.KindId = 11;
                            break;

                        case 0: // group 3 truck                        
                            o.Number = mskTruckNumber.Text;
                            o.KindId = Convert.ToInt64(cbbTruckKind.SelectedValue);
                            break;

                        case 4: // group 4 car               
                            o.Number = mskCarNumber.Text;
                            o.KindId = Convert.ToInt64(cbbCarKind.SelectedValue);
                            break;

                        case 3: // group 5 medium                        
                            o.Number = mskMediumNumber.Text;
                            o.KindId = 12;

                            break;

                        default:
                            break;
                    }

                    if (_dal.UpdateNumber(EditNumber, o))
                    {
                        UTL.CsoUTL.Show(STR_EDI_SUC);
                        GetInMinute();
                        cmdIn.Enabled = true;
                        cmdDelete.Enabled = false;
                        cmdEdit.Enabled = false;
                        EditNumber = null;
                        ClearText();
                        if (!EditMode) Close();
                    }
                    else UTL.CsoUTL.Show(STR_NOT_EDIT);

                }

                cmdEdit.Text = "&Sửa";
            }
        }

        private void dgvAep_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Stt();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var dal = new DAL.KindDAL();
                _currTabPageIndex = tabControl1.SelectedIndex;

                mskMediumC.Text = null;
                mskTruckL.Text = null;
                mskTruckW.Text = null;

                switch (tabControl1.SelectedIndex)
                {
                    case 1: // group 1
                        mskTaxiNumber.Text = _currVehicle.Number;
                        break;

                    case 2: // group 2
                        //mskThreeNumber.Text = _currVehicle.Number;
                        mskThreeNumber.Text = String.Format("BG{0}", _dal.Count());
                        break;

                    case 0: // group 3
                        mskTruckNumber.Text = _currVehicle.Number;
                        if (_currVehicle.Length != null)
                            mskTruckL.Text = _currVehicle.Length.Value + "";

                        if (_currVehicle.Weight != null)
                            mskTruckW.Text = _currVehicle.Weight.Value + "";
                        cbbTruckKind.DataSource = dal.GetData(1);
                        if (_currVehicle.KindId + "" != "")
                        {
                            if (_currVehicle.KindId > 0)
                                cbbTruckKind.SelectedValue = _currVehicle.KindId;
                            else cbbTruckKind.SelectedIndex = 0;
                        }
                        break;

                    case 4: // group 4

                        mskCarNumber.Text = _currVehicle.Number;
                        cbbCarKind.DataSource = dal.GetData(2);
                        if (_currVehicle.KindId + "" != "")
                        {
                            if (_currVehicle.KindId > 0)
                                cbbCarKind.SelectedValue = _currVehicle.KindId;
                            else cbbCarKind.SelectedIndex = 0;
                        }
                        break;

                    case 3: // group 5
                        mskMediumNumber.Text = _currVehicle.Number;

                        if (_currVehicle.Chair != null)
                            mskMediumC.Text = _currVehicle.Chair.Value + "";
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
            DataRow[] dr = dtb.Select(string.Format("Id='{0}'", cbbTruckKind.SelectedValue));

            if (dr.Length > 0)
            {
                string a1 = dr[0]["WeightMin"] + "";
                string a2 = dr[0]["WeightMax"] + "";
                string c1 = dr[0]["LengthMin"] + "";
                string c2 = dr[0]["LengthMax"] + "";

                _wMin = a1 == "" ? 0 : Convert.ToDecimal(a1);
                _wMax = a2 == "" ? 0 : Convert.ToDecimal(a2);
                _lMin = c1 == "" ? 0 : Convert.ToDecimal(c1);
                _lMax = c2 == "" ? 0 : Convert.ToDecimal(c2);
            }
        }

        private void cbbCarKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dtb = (DataTable)cbbCarKind.DataSource;
            DataRow[] dr = dtb.Select(string.Format("Id='{0}'", cbbCarKind.SelectedValue));

            if (dr.Length > 0)
            {
                string b1 = dr[0]["ChairMin"] + "";
                string b2 = dr[0]["ChairMax"] + "";

                _cMin = b1 == "" ? 0 : Convert.ToInt32(b1);
                _cMax = b2 == "" ? 0 : Convert.ToInt32(b2);
            }
        }

        private void cmdIn_Click(object sender, EventArgs e)
        {
            GetCurrObj(_currTabPageIndex);

            if (!ValidNumber()) return;

            //if (_currTabPageIndex == 2)
            //{
            //    if (mskTruckL.Text.Trim() + "" != "")
            //    {
            //        if (!ValidLenght()) return;
            //    }
            //    else if (mskTruckW.Text.Trim() + "" != "")
            //    {
            //        if (!ValidWeight()) return;
            //    }
            //    else
            //    {
            //        if (!(_lMax == 0 && _wMax == 0))
            //        {
            //            UTL.CsoUTL.Show("Nhập tải trọng hoặc chiều dài!");
            //            return;
            //        }
            //    }
            //}

            if (_currTabPageIndex == 3) if (!ValidChair()) return;

            int chair;
            decimal length, weight;
            if (!ConvertText(out chair, out length, out weight)) return; // fail to exit

            object detail;
            var ktr = new DAL.VehicleDAL();

            if (ktr.CheckExist(_currVehicle.Number)) // kiểm tra biển số xe trong danh sách các xe được quản lí
            {
                var o = new DAL.Detail()
                {
                    AccIn = _sss.Id,
                    Number = _currVehicle.Number,
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
                        Number = _currVehicle.Number,
                        KindId = _currVehicle.KindId,
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
                            Number = _currVehicle.Number,
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

        private void tmrDongHo_Tick(object sender, EventArgs e)
        {
            _sec++;
            if (_sec >= 10)
            {
                GetInMinute();
                _sec = 0;
            }
            if (_sss.Current != null) lblDateIn.Text = _sss.Current.Value.ToString(STR_DMY);
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

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Có chắc chắn xoá xe này không?", "Xoá xe", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;

            var dal = new DAL.DetailDAL();
            if (dal.DeleteByNumber(_currVehicle.Number))
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

        string _num;
        private void dgvAep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _row = e.RowIndex;
            _num = dgvAep.Rows[_row].Cells["colNumber"].Value.ToString();

            if (CheckExistsNumber(_num))
            {
                cmdEdit.Enabled = true;
                cmdDelete.Enabled = true;
                //cmdIn.Enabled = false;
                EditNumber = _num;
            }
            else
            {
                cmdEdit.Enabled = false;
                cmdDelete.Enabled = false;
                //cmdIn.Enabled = true;
                EditNumber = null;
            }
        }

        /*string _currentNumber;
        private void dgvAep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                _currentNumber = null;
                return;
            };

            _row = e.RowIndex;
            _currentNumber = dgvAep.Rows[_row].Cells["colNumber"].Value + "";
        }*/
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
            if (_lMax == 0) return true;

            var oki = UTL.SFI.CsoSFI.CheckNumber(mskTruckL.Text, _lMin, _lMax);
            if (!oki) UTL.CsoUTL.Show(STR_NOT_L);
            return oki;
        }

        private bool ValidWeight()
        {
            if (_wMax == 0) return true;

            var oki = UTL.SFI.CsoSFI.CheckNumber(mskTruckW.Text, _wMin, _wMax);
            if (!oki) UTL.CsoUTL.Show(STR_NOT_W);
            return oki;
        }

        private bool ValidNumber()
        {
            if (_currTabPageIndex == 2) return true; // not check ValidNumber three

            var oki = _currVehicle.Number.Length == 0 ? false : true;
            if (!oki) UTL.CsoUTL.Show(STR_NOT_INP);
            else
            {
                // Check format number
                if (_currVehicle.Number.Length > 2)
                {
                    int num;
                    string tmp = _currVehicle.Number.Substring(0, 2);
                    oki = oki && Int32.TryParse(tmp, out num);

                    tmp = _currVehicle.Number.Substring(2, 1);
                    oki = oki && !Int32.TryParse(tmp, out num);
                }
                else oki = false;

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
                    decimal length = tb.Rows[0]["Chair"] + "" != "" ? Convert.ToDecimal(tb.Rows[0]["Length"]) : 0;
                    decimal weight = tb.Rows[0]["Weight"] + "" != "" ? Convert.ToDecimal(tb.Rows[0]["Weight"]) : 0;

                    //cbbGroup.SelectedValue = tb.Rows[0]["GroupId"].ToString();
                    //cbbKind.SelectedValue = tb.Rows[0]["KindId"].ToString();

                    string kindId = tb.Rows[0]["KindId"].ToString();
                    if (kindId + "" != "")
                    {
                    }

                    string groupId = tb.Rows[0]["GroupId"].ToString();
                    if (groupId + "" != "")
                    {
                        int i = Convert.ToInt32(groupId);
                        switch (i)
                        {
                            case 1: // truck                                
                                _currTabPageIndex = 0;
                                tabControl1.SelectedIndex = _currTabPageIndex;
                                break;

                            case 2: // car
                                _currTabPageIndex = 4;
                                tabControl1.SelectedIndex = _currTabPageIndex;
                                break;

                            case 3: // taxi
                                _currTabPageIndex = 1;
                                tabControl1.SelectedIndex = _currTabPageIndex;
                                break;

                            case 4: // three
                                _currTabPageIndex = 2;
                                tabControl1.SelectedIndex = _currTabPageIndex;
                                break;

                            case 5: // medium
                                _currTabPageIndex = 3;
                                tabControl1.SelectedIndex = _currTabPageIndex;
                                break;

                            default:
                                break;
                        }
                    }

                    mskTruckW.Text = weight.ToString();
                    mskMediumC.Text = chair.ToString();
                    mskTruckL.Text = length.ToString();

                    //_obj.Number = tb.Rows[0]["Number"].ToString();
                    lblAccInName.Text = tb.Rows[0]["AccIn"].ToString().ToUpper();

                    _currVehicle.Number = number;
                    _currVehicle.Length = length;
                    _currVehicle.Weight = weight;
                    _currVehicle.Chair = chair;

                    switch (_currTabPageIndex)
                    {
                        case 1: // group 1 taxi
                            mskTaxiNumber.Text = number;
                            _currVehicle.KindId = 10;
                            break;

                        case 2: // group 2 three circle
                            mskThreeNumber.Text = number;
                            _currVehicle.KindId = 11;
                            break;

                        case 0: // group 3 truck
                            mskTruckNumber.Text = number;
                            _currVehicle.KindId = Convert.ToInt64(kindId);
                            cbbTruckKind.SelectedValue = kindId;
                            break;

                        case 4: // group 4 car
                            mskCarNumber.Text = number;
                            _currVehicle.KindId = Convert.ToInt64(kindId);
                            cbbCarKind.SelectedValue = kindId;
                            break;

                        case 3: // group 5 medium
                            mskMediumNumber.Text = number;
                            _currVehicle.KindId = 12;

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
            string num = number ?? _currVehicle.Number;
            var ktr = new DAL.VehicleDAL();
            var oki = ktr.CheckExist(num);
            if (oki) ShowDetail(num); // get information
            return oki;
        }

        private void ClearText()
        {
            mskTaxiNumber.Text = null;
            //mskThreeNumber.Text = null;
            mskThreeNumber.Text = String.Format("BG{0}", _dal.Count());
            mskTruckNumber.Text = null;
            mskTruckL.Text = null;
            mskTruckW.Text = null;
            mskCarNumber.Text = null;
            mskMediumNumber.Text = null;
            mskMediumC.Text = null;
            lblInf.Text = null;

            //_currVehicle.Number = "";
            //_currVehicle.Chair = 0;
            //_currVehicle.Weight = 0;
            //_currVehicle.Length = 0;

            _currVehicle = new DAL.Vehicle();
        }

        private void GetInMinute()
        {
            var tb = _dal.GetDataInMinute();
            if (tb.Rows.Count > 0)
            {
                dgvAep.DataSource = tb;

                //List<string> tmp = new List<string>();
                //foreach (DataRow dr in tb.Rows)
                //{
                //    tmp.Add(dr["Number"].ToString());
                //}

                //foreach (string xx in _listPreNumber)
                //{
                //    foreach (string yy in tmp)
                //    {
                //        if (xx == yy)
                //        {
                //            _listInNumber.Add(xx);
                //        }
                //    }
                //}

            }
            else
            {
                for (int i = 0; i < dgvAep.Rows.Count; i++)
                    dgvAep.Rows.RemoveAt(i);

                cmdIn.Enabled = true;
                cmdEdit.Enabled = false;
                cmdDelete.Enabled = false;
                //ClearText();
            }

            //string ok="";
            //foreach(string uu in _listInNumber)
            //{
            //    ok += uu + ";";
            //}

            //  lblInf.Text = ok;
        }

        private void Stt()
        {
            for (int i = 0; i < dgvAep.Rows.Count; i++)
                dgvAep.Rows[i].Cells["colNo_"].Value = i + 1;
        }

        private void GetCurrObj(int index)
        {
            if (EditHand)
            {
                _sss.Current = dtpDateIn.Value;
                tmrDongHo.Enabled = false;
            }
            else
            {
                tmrDongHo.Enabled = true;
                _sss.Current = _dal.CurrentTime();
            }

            switch (index)
            {
                case 1: // group 1 taxi
                    _currVehicle.Number = mskTaxiNumber.Text;
                    _currVehicle.KindId = 10;
                    break;

                case 2: // group 2 three circle
                    _currVehicle.Number = mskThreeNumber.Text;
                    _currVehicle.KindId = 11;
                    break;

                case 0: // group 3 truck
                    _currVehicle.Number = mskTruckNumber.Text;
                    _currVehicle.KindId = Convert.ToInt64(cbbTruckKind.SelectedValue);

                    string m1 = mskTruckW.Text.Trim();
                    string m2 = mskTruckL.Text.Trim();
                    if (m1 == "") m1 = "0";
                    if (m2 == "") m2 = "0";

                    decimal w, l;
                    Decimal.TryParse(m1, out w);
                    Decimal.TryParse(m2, out l);

                    _currVehicle.Weight = w;
                    _currVehicle.Weight = l;
                    break;

                case 4: // group 4 car
                    _currVehicle.Number = mskCarNumber.Text;
                    _currVehicle.KindId = Convert.ToInt64(cbbCarKind.SelectedValue);
                    break;

                case 3: // group 5 medium
                    _currVehicle.Number = mskMediumNumber.Text;
                    _currVehicle.KindId = 12;
                    m1 = mskMediumC.Text.Trim();
                    if (m1 == "") m1 = "0";

                    int c;
                    Int32.TryParse(m1, out c);
                    _currVehicle.Chair = c;

                    var dal = new DAL.KindDAL();
                    var tb = dal.GetData();
                    DataRow[] dr = tb.Select(string.Format("Id='{0}'", 12));
                    if (dr.Length > 0)
                    {
                        _cMax = Convert.ToInt32(dr[0]["ChairMax"]);
                        _cMin = Convert.ToInt32(dr[0]["ChairMin"]);
                    }
                    else
                    {
                        _cMax = 999;
                        _cMin = 0;
                    }
                    break;

                default:
                    break;
            }
        }

        private string ValidNumber(string txt)
        {
            txt = txt.ToUpper();

            if (CheckExistsNumber(txt))
            {
                lblInf.Text = STR_IN_MAG;
                ShowDetail(txt);
            }
            else lblInf.Text = null;

            return txt;
        }
        #endregion

        #region More
        /// <summary>
        /// Change status command button on form
        /// </summary>
        /// <param name="isEnable">Enable</param>
        protected void ChangeStatus(bool isEnable = true)
        {
            btnAdd.Enabled = isEnable;
            btnEdit.Enabled = isEnable;
            btnDelete.Enabled = isEnable;

            btnSave.Enabled = !isEnable;
            btnCancel.Enabled = !isEnable;
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChangeStatus(false);
            ReadOnlyControl(false);

            ClearDataBindings();
            ResetInput();
        }

        /// <summary>
        /// Set null value prompt
        /// </summary>
        private void SetNullPrompt() { }

        /// <summary>
        /// Reset all input control
        /// </summary>
        private void ResetInput() { }

        /// <summary>
        /// Clear data binding
        /// </summary>
        private void ClearDataBindings() { }

        /// <summary>
        /// Add data binding
        /// </summary>
        private void DataBindingControl() { }

        /// <summary>
        /// Set read only control on form
        /// </summary>
        /// <param name="isReadOnly">Read only</param>
        private void ReadOnlyControl(bool isReadOnly = true) { }

        /// <summary>
        /// Load data or perform when click refresh button
        /// </summary>
        private void PerformRefresh() { }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ChangeStatus(false);
            ReadOnlyControl(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ChangeStatus();
            ReadOnlyControl();
            PerformRefresh();
        }
    }
}