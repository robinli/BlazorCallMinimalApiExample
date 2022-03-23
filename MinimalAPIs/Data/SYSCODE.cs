using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MinimalAPIs.Data
{
    /// <summary>
    /// 系統代碼
    /// </summary>
    public partial class SYSCODE
    {

        /// <summary>
        /// 代碼ID，CKIND + 4 碼流水號
        /// </summary>
        [Key]
        [StringLength(64)]
        [Unicode(false)]
        public string CODE_ID { get; set; } = null!;
        [StringLength(32)]
        [Unicode(false)]
        public string CKIND { get; set; } = null!;

        /// <summary>
        /// 代碼，相同代碼大類的唯一值，若未輸入則等於 CODE_ID
        /// </summary>
        [StringLength(64)]
        [Unicode(false)]
        public string CODE_NO { get; set; } = null!;

        /// <summary>
        /// 代碼名稱
        /// </summary>
        [StringLength(64)]
        public string? CODE_NAME { get; set; }

        /// <summary>
        /// 說明描述
        /// </summary>
        [StringLength(256)]
        public string? DESCTXT { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        [StringLength(1)]
        [Unicode(false)]
        public string? ENABLED { get; set; }

        /// <summary>
        /// 排序，以雙數流水號遞增
        /// </summary>
        public int? ORDERNUM { get; set; }

        /// <summary>
        /// 公司代號
        /// </summary>
        [StringLength(4)]
        [Unicode(false)]
        public string? COMP_NO { get; set; }

        /// <summary>
        /// 部門代碼，公司代號 + 4 碼流水號
        /// </summary>
        [StringLength(8)]
        [Unicode(false)]
        public string? DEP_NO { get; set; }

        /// <summary>
        /// 刪除碼 Y , N
        /// </summary>
        [StringLength(1)]
        [Unicode(false)]
        public string? DEL_CODE { get; set; }
        public int? CHANGE_NUM { get; set; }
        [StringLength(8)]
        [Unicode(false)]
        public string? MOD_USER { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? MOD_UTC { get; set; }
    }
}
