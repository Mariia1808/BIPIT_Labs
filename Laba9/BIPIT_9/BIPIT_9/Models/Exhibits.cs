//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BIPIT_9.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exhibits
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exhibits()
        {
            this.Moving = new HashSet<Moving>();
        }
    
        public int id_exhibit { get; set; }
        public string exhibit { get; set; }
        public string author { get; set; }
        public string name { get; set; }
        public string material { get; set; }
        public string year { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Moving> Moving { get; set; }
    }
}
