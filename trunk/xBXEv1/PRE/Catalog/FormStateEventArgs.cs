using System;
using System.Collections.Generic;

namespace PRE.Catalog
{
    /// <summary>
    /// Sự kiện trên form
    /// </summary>
    public class FormStateEventArgs : EventArgs
    {
        public FrmBase.State LastFormState;
        public FrmBase.State NewFormState;

        public FormStateEventArgs(FrmBase.State lastFormState, FrmBase.State newFormState)
        {
            LastFormState = lastFormState;
            NewFormState = newFormState;
        }
    }
}