#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 10/11/2012 21:48
 * Update: 02/06/2013 07:12
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Collections.Generic;

namespace SKG.DXF.Help.Util
{
    /// <summary>
    /// This struct will contain the info from the xml file
    /// </summary>
    public struct VersionInfo
    {
        public bool error;
        public Version latestVersion;
        public string installerUrl;
        public string homeUrl;
        public string date;
    }
}
