//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BTCK
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_HoaDon()
        {
            this.tb_CTHD = new HashSet<tb_CTHD>();
        }
    
        public int MaHD { get; set; }
        public Nullable<System.DateTime> NgayLap { get; set; }
        public Nullable<int> KhachHang { get; set; }
        public Nullable<int> NguoiLap { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_CTHD> tb_CTHD { get; set; }
        public virtual tb_KhachHang tb_KhachHang { get; set; }
        public virtual tb_NhanVien tb_NhanVien { get; set; }
    }
}
