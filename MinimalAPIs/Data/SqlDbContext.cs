using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MinimalAPIs.Data
{
    public partial class SqlDbContext : DbContext
    {
        public virtual DbSet<SYSCODE> SYSCODE { get; set; } = null!;

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<SYSCODE>(entity =>
            {
                entity.HasComment("系統代碼");

                entity.Property(e => e.CODE_ID)
                    .IsUnicode(false)
                    .HasComment("代碼ID，CKIND + 4 碼流水號");

                entity.Property(e => e.CHANGE_NUM).HasDefaultValueSql("((0))");

                entity.Property(e => e.CKIND).IsUnicode(false);

                entity.Property(e => e.CODE_NAME).HasComment("代碼名稱");

                entity.Property(e => e.CODE_NO)
                    .IsUnicode(false)
                    .HasComment("代碼，相同代碼大類的唯一值，若未輸入則等於 CODE_ID");

                entity.Property(e => e.COMP_NO)
                    .IsUnicode(false)
                    .HasComment("公司代號");

                entity.Property(e => e.DEL_CODE)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .HasComment("刪除碼 Y , N");

                entity.Property(e => e.DEP_NO)
                    .IsUnicode(false)
                    .HasComment("部門代碼，公司代號 + 4 碼流水號");

                entity.Property(e => e.DESCTXT).HasComment("說明描述");

                entity.Property(e => e.ENABLED)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Y')")
                    .HasComment("是否啟用");

                entity.Property(e => e.MOD_USER).IsUnicode(false);

                entity.Property(e => e.ORDERNUM).HasComment("排序，以雙數流水號遞增");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
