using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Clinic_Management_System.Models
{
    public partial class CMSContext : DbContext
    {
        public CMSContext()
        {
        }

        public CMSContext(DbContextOptions<CMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authentications> Authentications { get; set; }
        public virtual DbSet<ConsultationBills> ConsultationBills { get; set; }
        public virtual DbSet<LabBills> LabBills { get; set; }
        public virtual DbSet<Manufactures> Manufactures { get; set; }
        public virtual DbSet<MedicalHistory> MedicalHistory { get; set; }
        public virtual DbSet<MedicineBills> MedicineBills { get; set; }
        public virtual DbSet<MedicineDetails> MedicineDetails { get; set; }
        public virtual DbSet<MedicineInventories> MedicineInventories { get; set; }
        public virtual DbSet<MedicineLists> MedicineLists { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<PrescribedMedicines> PrescribedMedicines { get; set; }
        public virtual DbSet<Qualifications> Qualifications { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Staffs> Staffs { get; set; }
        public virtual DbSet<TestAdvices> TestAdvices { get; set; }
        public virtual DbSet<TestDetails> TestDetails { get; set; }
        public virtual DbSet<TestLists> TestLists { get; set; }
        public virtual DbSet<TestReports> TestReports { get; set; }
        public virtual DbSet<Tokens> Tokens { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Vitals> Vitals { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= ALFINASULFIKAR\\SQLEXPRESS; Initial Catalog= CMS; Integrated security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authentications>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__authenti__B9BE370FCA1CBBB8");

                entity.ToTable("authentications");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Authentications)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__authentic__staff__4BAC3F29");
            });

            modelBuilder.Entity<ConsultationBills>(entity =>
            {
                entity.HasKey(e => e.ConsultationBillId)
                    .HasName("PK__consulta__DD3FD6679E66CFF8");

                entity.ToTable("consultation_bills");

                entity.Property(e => e.ConsultationBillId).HasColumnName("consultation_bill_id");

                entity.Property(e => e.ConsultationAmount).HasColumnName("consultation_amount");

                entity.Property(e => e.ConsultationDateTime)
                    .HasColumnName("consultation_date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.ConsultationBills)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__consultat__patie__4E88ABD4");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.ConsultationBills)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__consultat__staff__4F7CD00D");
            });

            modelBuilder.Entity<LabBills>(entity =>
            {
                entity.HasKey(e => e.LabBillId)
                    .HasName("PK__lab_bill__F353DA8EB255CFC5");

                entity.ToTable("lab_bills");

                entity.Property(e => e.LabBillId).HasColumnName("lab_bill_id");

                entity.Property(e => e.LabBillAmount).HasColumnName("lab_bill_amount");

                entity.Property(e => e.LabBillDateTime)
                    .HasColumnName("lab_bill_date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.TestListId).HasColumnName("test_list_id");

                entity.Property(e => e.TestName)
                    .IsRequired()
                    .HasColumnName("test_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.LabBills)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__lab_bills__patie__6754599E");

                entity.HasOne(d => d.TestList)
                    .WithMany(p => p.LabBills)
                    .HasForeignKey(d => d.TestListId)
                    .HasConstraintName("FK__lab_bills__test___66603565");
            });

            modelBuilder.Entity<Manufactures>(entity =>
            {
                entity.HasKey(e => e.ManufactureId)
                    .HasName("PK__manufact__1F2B08C33C317FB3");

                entity.ToTable("manufactures");

                entity.Property(e => e.ManufactureId).HasColumnName("manufacture_id");

                entity.Property(e => e.ManufactureAddress)
                    .IsRequired()
                    .HasColumnName("manufacture_address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManufactureEmail)
                    .IsRequired()
                    .HasColumnName("manufacture_email")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ManufactureName)
                    .IsRequired()
                    .HasColumnName("manufacture_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManufacturePhone)
                    .IsRequired()
                    .HasColumnName("manufacture_phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicalHistory>(entity =>
            {
                entity.HasKey(e => e.MedicalListId)
                    .HasName("PK__medical___4CECA9C70F566904");

                entity.ToTable("medical_history");

                entity.Property(e => e.MedicalListId).HasColumnName("medical_list_id");

                entity.Property(e => e.NewData)
                    .HasColumnName("new_data")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OldData)
                    .HasColumnName("old_data")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.MedicalHistory)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__medical_h__patie__787EE5A0");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.MedicalHistory)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__medical_h__staff__797309D9");
            });

            modelBuilder.Entity<MedicineBills>(entity =>
            {
                entity.HasKey(e => e.MedicineBillId)
                    .HasName("PK__medicine__B47E7D0F466FFFE8");

                entity.ToTable("medicine_bills");

                entity.Property(e => e.MedicineBillId).HasColumnName("medicine_bill_id");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.MedicineAmount).HasColumnName("medicine_amount");

                entity.Property(e => e.MedicineBillDateTime)
                    .HasColumnName("medicine_bill_date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasColumnName("medicine_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineQuantity).HasColumnName("medicine_quantity");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.PrescriptionId).HasColumnName("prescription_id");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.MedicineBills)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK__medicine___inven__70DDC3D8");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.MedicineBills)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__medicine___patie__6FE99F9F");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.MedicineBills)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__medicine___presc__71D1E811");
            });

            modelBuilder.Entity<MedicineDetails>(entity =>
            {
                entity.HasKey(e => e.MedicineId)
                    .HasName("PK__medicine__E7148EBB46465E6B");

                entity.ToTable("medicine_details");

                entity.Property(e => e.MedicineId).HasColumnName("medicine_id");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("expiry_date")
                    .HasColumnType("date");

                entity.Property(e => e.ManufacturingDate)
                    .HasColumnName("manufacturing_date")
                    .HasColumnType("date");

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasColumnName("medicine_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MedicinePrice).HasColumnName("medicine_price");

                entity.Property(e => e.MedicineQuantity).HasColumnName("medicine_quantity");
            });

            modelBuilder.Entity<MedicineInventories>(entity =>
            {
                entity.HasKey(e => e.InventoryId)
                    .HasName("PK__medicine__B59ACC49BC0FE7DC");

                entity.ToTable("medicine_inventories");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.ManufactureId).HasColumnName("manufacture_id");

                entity.Property(e => e.MedicineId).HasColumnName("medicine_id");

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasColumnName("medicine_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineQuantity).HasColumnName("medicine_quantity");

                entity.Property(e => e.MedicineType)
                    .IsRequired()
                    .HasColumnName("medicine_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manufacture)
                    .WithMany(p => p.MedicineInventories)
                    .HasForeignKey(d => d.ManufactureId)
                    .HasConstraintName("FK__medicine___manuf__6D0D32F4");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.MedicineInventories)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__medicine___medic__6C190EBB");
            });

            modelBuilder.Entity<MedicineLists>(entity =>
            {
                entity.HasKey(e => e.MedicineListId)
                    .HasName("PK__medicine__43D1547C6FDB4D61");

                entity.ToTable("medicine_lists");

                entity.Property(e => e.MedicineListId).HasColumnName("medicine_list_id");

                entity.Property(e => e.Dosage).HasColumnName("dosage");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.MedicineId).HasColumnName("medicine_id");

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasColumnName("medicine_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PrescriptionId).HasColumnName("prescription_id");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.MedicineLists)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__medicine___medic__74AE54BC");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.MedicineLists)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__medicine___presc__75A278F5");
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__patients__4D5CE476AF867F45");

                entity.ToTable("patients");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.PatientBlood)
                    .IsRequired()
                    .HasColumnName("patient_blood")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PatientDob)
                    .HasColumnName("patient_dob")
                    .HasColumnType("date");

                entity.Property(e => e.PatientGender)
                    .IsRequired()
                    .HasColumnName("patient_gender")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PatientLocation)
                    .IsRequired()
                    .HasColumnName("patient_location")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasColumnName("patient_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PatientPhone)
                    .IsRequired()
                    .HasColumnName("patient_phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PatientWeight).HasColumnName("patient_weight");
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__payments__ED1FC9EAF53CD7FC");

                entity.ToTable("payments");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasColumnName("payment_mode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentsDateTime)
                    .HasColumnName("payments_date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransactionNumber).HasColumnName("transaction_number");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__payments__patien__412EB0B6");
            });

            modelBuilder.Entity<PrescribedMedicines>(entity =>
            {
                entity.HasKey(e => e.PrescriptionId)
                    .HasName("PK__prescrib__3EE444F86B62F41B");

                entity.ToTable("prescribed_medicines");

                entity.Property(e => e.PrescriptionId).HasColumnName("prescription_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.PrescriptionDateTime)
                    .HasColumnName("prescription_date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PrescribedMedicines)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__prescribe__patie__5629CD9C");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.PrescribedMedicines)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__prescribe__staff__571DF1D5");
            });

            modelBuilder.Entity<Qualifications>(entity =>
            {
                entity.HasKey(e => e.QualificationId)
                    .HasName("PK__qualific__CDACC5DBE558D48D");

                entity.ToTable("qualifications");

                entity.Property(e => e.QualificationId).HasColumnName("qualification_id");

                entity.Property(e => e.QualificationName)
                    .IsRequired()
                    .HasColumnName("qualification_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Qualifications)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__qualifica__staff__48CFD27E");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__roles__760965CCA2E23EA3");

                entity.ToTable("roles");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("role_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staffs>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK__staffs__1963DD9C070DEFA4");

                entity.ToTable("staffs");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.StaffAddress)
                    .IsRequired()
                    .HasColumnName("staff_address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffDob)
                    .HasColumnName("staff_dob")
                    .HasColumnType("date");

                entity.Property(e => e.StaffEmail)
                    .IsRequired()
                    .HasColumnName("staff_email")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StaffJoiningDate)
                    .HasColumnName("staff_joining_date")
                    .HasColumnType("date");

                entity.Property(e => e.StaffName)
                    .IsRequired()
                    .HasColumnName("staff_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffPhone)
                    .IsRequired()
                    .HasColumnName("staff_phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestAdvices>(entity =>
            {
                entity.HasKey(e => e.AdviceId)
                    .HasName("PK__test_adv__A2B9EF6A5173394A");

                entity.ToTable("test_advices");

                entity.Property(e => e.AdviceId).HasColumnName("advice_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.TestAdviceDateTime)
                    .HasColumnName("test_advice_date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.TestName)
                    .IsRequired()
                    .HasColumnName("test_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TestAdvices)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__test_advi__patie__5EBF139D");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.TestAdvices)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__test_advi__staff__5FB337D6");
            });

            modelBuilder.Entity<TestDetails>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("PK__test_det__F3FF1C0249933CAD");

                entity.ToTable("test_details");

                entity.Property(e => e.TestId).HasColumnName("test_id");

                entity.Property(e => e.MaximumValue).HasColumnName("maximum_value");

                entity.Property(e => e.MinimumValue).HasColumnName("minimum_value");

                entity.Property(e => e.NormalValue).HasColumnName("normal_value");

                entity.Property(e => e.TestAmount).HasColumnName("test_amount");

                entity.Property(e => e.TestName)
                    .IsRequired()
                    .HasColumnName("test_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestLists>(entity =>
            {
                entity.HasKey(e => e.TestListId)
                    .HasName("PK__test_lis__932FE13080A93677");

                entity.ToTable("test_lists");

                entity.Property(e => e.TestListId).HasColumnName("test_list_id");

                entity.Property(e => e.AdviceId).HasColumnName("advice_id");

                entity.Property(e => e.TestAmount).HasColumnName("test_amount");

                entity.Property(e => e.TestId).HasColumnName("test_id");

                entity.Property(e => e.TestName)
                    .IsRequired()
                    .HasColumnName("test_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Advice)
                    .WithMany(p => p.TestLists)
                    .HasForeignKey(d => d.AdviceId)
                    .HasConstraintName("FK__test_list__advic__628FA481");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestLists)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__test_list__test___6383C8BA");
            });

            modelBuilder.Entity<TestReports>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__test_rep__779B7C58EAAFB117");

                entity.ToTable("test_reports");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasColumnName("patient_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PatientValue).HasColumnName("patient_value");

                entity.Property(e => e.ReportDateTime)
                    .HasColumnName("report_date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.TestId).HasColumnName("test_id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TestReports)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__test_repo__patie__59FA5E80");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.TestReports)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__test_repo__staff__5AEE82B9");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestReports)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__test_repo__test___5BE2A6F2");
            });

            modelBuilder.Entity<Tokens>(entity =>
            {
                entity.HasKey(e => e.TokenId)
                    .HasName("PK__tokens__CB3C9E172875B95C");

                entity.ToTable("tokens");

                entity.Property(e => e.TokenId).HasColumnName("token_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.TokenDateTime)
                    .HasColumnName("token_date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.TokenNum).HasColumnName("token_num");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Tokens)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__tokens__patient___52593CB8");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Tokens)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__tokens__staff_id__534D60F1");
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("PK__units__D3AF5BD7BFF02ED8");

                entity.ToTable("units");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.TestId).HasColumnName("test_id");

                entity.Property(e => e.TestUnit)
                    .IsRequired()
                    .HasColumnName("test_unit")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__units__test_id__440B1D61");
            });

            modelBuilder.Entity<Vitals>(entity =>
            {
                entity.HasKey(e => e.VitalId)
                    .HasName("PK__vitals__4DF3C47104175222");

                entity.ToTable("vitals");

                entity.Property(e => e.VitalId).HasColumnName("vital_id");

                entity.Property(e => e.BloodPressure).HasColumnName("blood_pressure");

                entity.Property(e => e.BodyTemp).HasColumnName("body_temp");

                entity.Property(e => e.BreathRate).HasColumnName("breath_rate");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.PulseRate).HasColumnName("pulse_rate");

                entity.Property(e => e.VitalDateTime)
                    .HasColumnName("vital_date_time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Vitals)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__vitals__patient___3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
