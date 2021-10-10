using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace saemp_backend.Models
{
    public partial class DBSaempContext : DbContext
    {
        public DBSaempContext()
        {
        }

        public DBSaempContext(DbContextOptions<DBSaempContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AmBinnaclePayment> AmBinnaclePayments { get; set; }
        public virtual DbSet<AmDiscount> AmDiscounts { get; set; }
        public virtual DbSet<AmDiscountVersion> AmDiscountVersions { get; set; }
        public virtual DbSet<AmPaymentConcept> AmPaymentConcepts { get; set; }
        public virtual DbSet<AmPaymentMethod> AmPaymentMethods { get; set; }
        public virtual DbSet<AmPaymentReceipt> AmPaymentReceipts { get; set; }
        public virtual DbSet<AmPaymentReceiptDetail> AmPaymentReceiptDetails { get; set; }
        public virtual DbSet<AmPaymentStatus> AmPaymentStatuses { get; set; }
        public virtual DbSet<AmPaymentTransaction> AmPaymentTransactions { get; set; }
        public virtual DbSet<AmPaymentTransactionDetail> AmPaymentTransactionDetails { get; set; }
        public virtual DbSet<AmSchoolYearPayment> AmSchoolYearPayments { get; set; }
        public virtual DbSet<AmStudentInstallment> AmStudentInstallments { get; set; }
        public virtual DbSet<EmEnrollment> EmEnrollments { get; set; }
        public virtual DbSet<EmSchoolYear> EmSchoolYears { get; set; }
        public virtual DbSet<EmSchoolYearLevel> EmSchoolYearLevels { get; set; }
        public virtual DbSet<EpAcademicLevel> EpAcademicLevels { get; set; }
        public virtual DbSet<EpScholarStatus> EpScholarStatuses { get; set; }
        public virtual DbSet<EpSchoolLevel> EpSchoolLevels { get; set; }
        public virtual DbSet<EpSchoolOrigin> EpSchoolOrigins { get; set; }
        public virtual DbSet<EpStudentDocumentType> EpStudentDocumentTypes { get; set; }
        public virtual DbSet<HrEmployee> HrEmployees { get; set; }
        public virtual DbSet<HrEmploymentContract> HrEmploymentContracts { get; set; }
        public virtual DbSet<HrJobTitle> HrJobTitles { get; set; }
        public virtual DbSet<InCampus> InCampuses { get; set; }
        public virtual DbSet<InRoom> InRooms { get; set; }
        public virtual DbSet<PmCountry> PmCountries { get; set; }
        public virtual DbSet<PmDepartment> PmDepartments { get; set; }
        public virtual DbSet<PmDistrict> PmDistricts { get; set; }
        public virtual DbSet<PmPerson> PmPeople { get; set; }
        public virtual DbSet<PmPhone> PmPhones { get; set; }
        public virtual DbSet<PmPhoneCompany> PmPhoneCompanies { get; set; }
        public virtual DbSet<PmPhoneType> PmPhoneTypes { get; set; }
        public virtual DbSet<PmTypeDocumentIdentity> PmTypeDocumentIdentities { get; set; }
        public virtual DbSet<SmRelationship> SmRelationships { get; set; }
        public virtual DbSet<SmRelative> SmRelatives { get; set; }
        public virtual DbSet<SmStudent> SmStudents { get; set; }
        public virtual DbSet<SmStudentDocument> SmStudentDocuments { get; set; }
        public virtual DbSet<SmStudentSchoolOrigin> SmStudentSchoolOrigins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBSaemp");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AmBinnaclePayment>(entity =>
            {
                entity.HasKey(e => e.IdBinnaclePayment)
                    .HasName("PK_BinnaclePayment");

                entity.ToTable("amBinnaclePayment");

                entity.Property(e => e.IdBinnaclePayment).HasColumnName("idBinnaclePayment");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.IdEnrollment).HasColumnName("idEnrollment");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registrationDate");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.AmBinnaclePayments)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BinnaclePayment_Employee");

                entity.HasOne(d => d.IdEnrollmentNavigation)
                    .WithMany(p => p.AmBinnaclePayments)
                    .HasForeignKey(d => d.IdEnrollment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BinnaclePayment_Enrollment");
            });

            modelBuilder.Entity<AmDiscount>(entity =>
            {
                entity.HasKey(e => e.IdDiscount)
                    .HasName("PK_Discount");

                entity.ToTable("amDiscount");

                entity.Property(e => e.IdDiscount).HasColumnName("idDiscount");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.NeedValidation).HasColumnName("needValidation");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registrationDate");
            });

            modelBuilder.Entity<AmDiscountVersion>(entity =>
            {
                entity.HasKey(e => e.IdDiscountVersion)
                    .HasName("PK_DiscountVersion");

                entity.ToTable("amDiscountVersion");

                entity.Property(e => e.IdDiscountVersion).HasColumnName("idDiscountVersion");

                entity.Property(e => e.DiscountAmount)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("discountAmount");

                entity.Property(e => e.DiscountRate)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("discountRate");

                entity.Property(e => e.FinalDate)
                    .HasColumnType("datetime")
                    .HasColumnName("finalDate");

                entity.Property(e => e.IdDiscount).HasColumnName("idDiscount");

                entity.Property(e => e.IsRate).HasColumnName("isRate");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("startDate");

                entity.HasOne(d => d.IdDiscountNavigation)
                    .WithMany(p => p.AmDiscountVersions)
                    .HasForeignKey(d => d.IdDiscount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiscountVersion_Discount");
            });

            modelBuilder.Entity<AmPaymentConcept>(entity =>
            {
                entity.HasKey(e => e.IdPaymentConcept)
                    .HasName("PK_PaymentConcept");

                entity.ToTable("amPaymentConcept");

                entity.Property(e => e.IdPaymentConcept).HasColumnName("idPaymentConcept");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<AmPaymentMethod>(entity =>
            {
                entity.HasKey(e => e.IdPaymentMethod)
                    .HasName("PK_PaymentMethod");

                entity.ToTable("amPaymentMethod");

                entity.Property(e => e.IdPaymentMethod).HasColumnName("idPaymentMethod");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("abbreviation")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<AmPaymentReceipt>(entity =>
            {
                entity.HasKey(e => e.IdPaymentReceipt)
                    .HasName("PK_PaymentReceipt");

                entity.ToTable("amPaymentReceipt");

                entity.Property(e => e.IdPaymentReceipt).HasColumnName("idPaymentReceipt");

                entity.Property(e => e.Comment)
                    .HasMaxLength(250)
                    .HasColumnName("comment");

                entity.Property(e => e.IdCampus).HasColumnName("idCampus");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("paymentDate");

                entity.Property(e => e.ReceiptNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("receiptNumber");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registrationDate");

                entity.Property(e => e.SerieNumber)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("serieNumber");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("totalAmount");

                entity.HasOne(d => d.IdCampusNavigation)
                    .WithMany(p => p.AmPaymentReceipts)
                    .HasForeignKey(d => d.IdCampus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentReceipt_Campus");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.AmPaymentReceipts)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentReceipt_Employee");
            });

            modelBuilder.Entity<AmPaymentReceiptDetail>(entity =>
            {
                entity.HasKey(e => e.IdPaymentReceiptDetail)
                    .HasName("PK_PaymentReceiptDetail");

                entity.ToTable("amPaymentReceiptDetail");

                entity.Property(e => e.IdPaymentReceiptDetail).HasColumnName("idPaymentReceiptDetail");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.IdPaymentReceipt).HasColumnName("idPaymentReceipt");

                entity.Property(e => e.IdStudentInstallment).HasColumnName("idStudentInstallment");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("totalAmount");

                entity.HasOne(d => d.IdPaymentReceiptNavigation)
                    .WithMany(p => p.AmPaymentReceiptDetails)
                    .HasForeignKey(d => d.IdPaymentReceipt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentReceiptDetail_PaymentReceipt");

                entity.HasOne(d => d.IdStudentInstallmentNavigation)
                    .WithMany(p => p.AmPaymentReceiptDetails)
                    .HasForeignKey(d => d.IdStudentInstallment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentReceiptDetail_StudentInstallment");
            });

            modelBuilder.Entity<AmPaymentStatus>(entity =>
            {
                entity.HasKey(e => e.IdPaymentStatus)
                    .HasName("PK_PaymentStatus");

                entity.ToTable("amPaymentStatus");

                entity.Property(e => e.IdPaymentStatus).HasColumnName("idPaymentStatus");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("abbreviation")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<AmPaymentTransaction>(entity =>
            {
                entity.HasKey(e => e.IdPaymentTransaction)
                    .HasName("PK_PaymentTransaction");

                entity.ToTable("amPaymentTransaction");

                entity.Property(e => e.IdPaymentTransaction).HasColumnName("idPaymentTransaction");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.IdPaymentMethod).HasColumnName("idPaymentMethod");

                entity.Property(e => e.NumberTransaction)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("numberTransaction");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("paymentDate");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registrationDate");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("totalAmount");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.AmPaymentTransactions)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentTransaction_Employee");

                entity.HasOne(d => d.IdPaymentMethodNavigation)
                    .WithMany(p => p.AmPaymentTransactions)
                    .HasForeignKey(d => d.IdPaymentMethod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentTransaction_PaymentMethod");
            });

            modelBuilder.Entity<AmPaymentTransactionDetail>(entity =>
            {
                entity.HasKey(e => e.IdPaymentTransaction)
                    .HasName("PK_PaymentTransactionDetail");

                entity.ToTable("amPaymentTransactionDetail");

                entity.Property(e => e.IdPaymentTransaction)
                    .ValueGeneratedNever()
                    .HasColumnName("idPaymentTransaction");

                entity.Property(e => e.IdPaymentReceiptDetail).HasColumnName("idPaymentReceiptDetail");

                entity.Property(e => e.IdPaymentTransactionDetail)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idPaymentTransactionDetail");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("totalAmount");

                entity.HasOne(d => d.IdPaymentReceiptDetailNavigation)
                    .WithMany(p => p.AmPaymentTransactionDetails)
                    .HasForeignKey(d => d.IdPaymentReceiptDetail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentTransactionDetail_PaymentReceiptDetail");

                entity.HasOne(d => d.IdPaymentTransactionNavigation)
                    .WithOne(p => p.AmPaymentTransactionDetail)
                    .HasForeignKey<AmPaymentTransactionDetail>(d => d.IdPaymentTransaction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentTransactionDetail_PaymentTransaction");
            });

            modelBuilder.Entity<AmSchoolYearPayment>(entity =>
            {
                entity.HasKey(e => e.IdSchoolYearPayment)
                    .HasName("PK_SchoolYearPayment");

                entity.ToTable("amSchoolYearPayment");

                entity.Property(e => e.IdSchoolYearPayment).HasColumnName("idSchoolYearPayment");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.IdPaymentConcept).HasColumnName("idPaymentConcept");

                entity.Property(e => e.IdSchoolYearLevel).HasColumnName("idSchoolYearLevel");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdPaymentConceptNavigation)
                    .WithMany(p => p.AmSchoolYearPayments)
                    .HasForeignKey(d => d.IdPaymentConcept)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SchoolYearPayment_PaymentConcept");

                entity.HasOne(d => d.IdSchoolYearLevelNavigation)
                    .WithMany(p => p.AmSchoolYearPayments)
                    .HasForeignKey(d => d.IdSchoolYearLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SchoolYearPayment_SchoolYearLevel");
            });

            modelBuilder.Entity<AmStudentInstallment>(entity =>
            {
                entity.HasKey(e => e.IdStudentInstallment)
                    .HasName("PK_StudentInstallment");

                entity.ToTable("amStudentInstallment");

                entity.Property(e => e.IdStudentInstallment).HasColumnName("idStudentInstallment");

                entity.Property(e => e.AmountDiscount)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("amountDiscount");

                entity.Property(e => e.AmountPaid)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("amountPaid");

                entity.Property(e => e.AmountRemainder)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("amountRemainder");

                entity.Property(e => e.AmountSubTotal)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("amountSubTotal");

                entity.Property(e => e.AmountTotal)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("amountTotal");

                entity.Property(e => e.IdDiscountVersion).HasColumnName("idDiscountVersion");

                entity.Property(e => e.IdEnrollment).HasColumnName("idEnrollment");

                entity.Property(e => e.IdPaymentStatus).HasColumnName("idPaymentStatus");

                entity.Property(e => e.IdSchoolYearPayment).HasColumnName("idSchoolYearPayment");

                entity.Property(e => e.TotalPaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("totalPaymentDate");

                entity.HasOne(d => d.IdDiscountVersionNavigation)
                    .WithMany(p => p.AmStudentInstallments)
                    .HasForeignKey(d => d.IdDiscountVersion)
                    .HasConstraintName("FK_StudentInstallment_DiscountVersion");

                entity.HasOne(d => d.IdEnrollmentNavigation)
                    .WithMany(p => p.AmStudentInstallments)
                    .HasForeignKey(d => d.IdEnrollment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentInstallment_Enrollment");

                entity.HasOne(d => d.IdPaymentStatusNavigation)
                    .WithMany(p => p.AmStudentInstallments)
                    .HasForeignKey(d => d.IdPaymentStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentInstallment_PaymentStatus");

                entity.HasOne(d => d.IdSchoolYearPaymentNavigation)
                    .WithMany(p => p.AmStudentInstallments)
                    .HasForeignKey(d => d.IdSchoolYearPayment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentInstallment_SchoolYearPayment");
            });

            modelBuilder.Entity<EmEnrollment>(entity =>
            {
                entity.HasKey(e => e.IdEnrollment)
                    .HasName("PK_Enrollment");

                entity.ToTable("emEnrollment");

                entity.Property(e => e.IdEnrollment).HasColumnName("idEnrollment");

                entity.Property(e => e.AdmissionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("admissionDate");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.EnrollmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("enrollmentDate");

                entity.Property(e => e.IdDiscountVersion).HasColumnName("idDiscountVersion");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.IdStudent)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("idStudent")
                    .IsFixedLength(true);

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("startDate");

                entity.HasOne(d => d.IdDiscountVersionNavigation)
                    .WithMany(p => p.EmEnrollments)
                    .HasForeignKey(d => d.IdDiscountVersion)
                    .HasConstraintName("FK_Enrollment_DiscountVersion");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.EmEnrollments)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enrollment_Employee");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.EmEnrollments)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enrollment_Student");
            });

            modelBuilder.Entity<EmSchoolYear>(entity =>
            {
                entity.HasKey(e => e.IdSchoolYear)
                    .HasName("PK_SchoolYear");

                entity.ToTable("emSchoolYear");

                entity.Property(e => e.IdSchoolYear).HasColumnName("idSchoolYear");

                entity.Property(e => e.ClassStartDate)
                    .HasColumnType("date")
                    .HasColumnName("classStartDate");

                entity.Property(e => e.DueDay).HasColumnName("dueDay");

                entity.Property(e => e.IdAcademicLevel).HasColumnName("idAcademicLevel");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.NewStudent).HasColumnName("newStudent");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.IdAcademicLevelNavigation)
                    .WithMany(p => p.EmSchoolYears)
                    .HasForeignKey(d => d.IdAcademicLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SchoolYear_AcademicLevel");
            });

            modelBuilder.Entity<EmSchoolYearLevel>(entity =>
            {
                entity.HasKey(e => e.IdSchoolYearLevel)
                    .HasName("PK_SchoolYearLevel");

                entity.ToTable("emSchoolYearLevel");

                entity.Property(e => e.IdSchoolYearLevel).HasColumnName("idSchoolYearLevel");

                entity.Property(e => e.IdSchoolLevel).HasColumnName("idSchoolLevel");

                entity.Property(e => e.IdSchoolYear).HasColumnName("idSchoolYear");

                entity.Property(e => e.NewStudentEnrolledAmount).HasColumnName("newStudentEnrolledAmount");

                entity.Property(e => e.TotalStudentEnrolledAmount).HasColumnName("totalStudentEnrolledAmount");

                entity.Property(e => e.VacancyAmount).HasColumnName("vacancyAmount");

                entity.HasOne(d => d.IdSchoolLevelNavigation)
                    .WithMany(p => p.EmSchoolYearLevels)
                    .HasForeignKey(d => d.IdSchoolLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SchoolYearLevel_SchoolLevel");

                entity.HasOne(d => d.IdSchoolYearNavigation)
                    .WithMany(p => p.EmSchoolYearLevels)
                    .HasForeignKey(d => d.IdSchoolYear)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SchoolYearLevel_SchoolYear");
            });

            modelBuilder.Entity<EpAcademicLevel>(entity =>
            {
                entity.HasKey(e => e.IdAcademicLevel)
                    .HasName("PK_AcademicLevel");

                entity.ToTable("epAcademicLevel");

                entity.Property(e => e.IdAcademicLevel).HasColumnName("idAcademicLevel");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("abbreviation")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<EpScholarStatus>(entity =>
            {
                entity.HasKey(e => e.IdScholarStatus)
                    .HasName("PK_SchoolStatus");

                entity.ToTable("epScholarStatus");

                entity.Property(e => e.IdScholarStatus).HasColumnName("idScholarStatus");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("abbreviation")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<EpSchoolLevel>(entity =>
            {
                entity.HasKey(e => e.IdSchoolLevel)
                    .HasName("PK_SchoolLevel");

                entity.ToTable("epSchoolLevel");

                entity.Property(e => e.IdSchoolLevel).HasColumnName("idSchoolLevel");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("abbreviation")
                    .IsFixedLength(true);

                entity.Property(e => e.IdAcademicLevel).HasColumnName("idAcademicLevel");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdAcademicLevelNavigation)
                    .WithMany(p => p.EpSchoolLevels)
                    .HasForeignKey(d => d.IdAcademicLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SchoolLevel_AcademicLevel");
            });

            modelBuilder.Entity<EpSchoolOrigin>(entity =>
            {
                entity.HasKey(e => e.IdSchoolOrigin)
                    .HasName("PK_SchoolOrigin");

                entity.ToTable("epSchoolOrigin");

                entity.Property(e => e.IdSchoolOrigin).HasColumnName("idSchoolOrigin");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.IdDepartment).HasColumnName("idDepartment");

                entity.Property(e => e.IdDistrict).HasColumnName("idDistrict");

                entity.Property(e => e.IsPrivate).HasColumnName("isPrivate");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdDepartmentNavigation)
                    .WithMany(p => p.EpSchoolOrigins)
                    .HasForeignKey(d => d.IdDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SchoolOrigin_Department");
            });

            modelBuilder.Entity<EpStudentDocumentType>(entity =>
            {
                entity.HasKey(e => e.IdStudentDocumentType)
                    .HasName("PK_StudentDocumentType");

                entity.ToTable("epStudentDocumentType");

                entity.Property(e => e.IdStudentDocumentType).HasColumnName("idStudentDocumentType");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("abbreviation")
                    .IsFixedLength(true);

                entity.Property(e => e.EffectiveDate)
                    .HasColumnType("date")
                    .HasColumnName("effectiveDate");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("date")
                    .HasColumnName("expirationDate");

                entity.Property(e => e.InEffect).HasColumnName("inEffect");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<HrEmployee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PK_Employee");

                entity.ToTable("hrEmployee");

                entity.Property(e => e.IdEmployee)
                    .ValueGeneratedNever()
                    .HasColumnName("idEmployee");

                entity.Property(e => e.InactivityTime).HasColumnName("inactivityTime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("userName");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .HasColumnName("userPassword");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithOne(p => p.HrEmployee)
                    .HasForeignKey<HrEmployee>(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Person");
            });

            modelBuilder.Entity<HrEmploymentContract>(entity =>
            {
                entity.HasKey(e => e.IdEmploymentContract)
                    .HasName("PK_EmploymentContract");

                entity.ToTable("hrEmploymentContract");

                entity.Property(e => e.IdEmploymentContract).HasColumnName("idEmploymentContract");

                entity.Property(e => e.AdmissionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("admissionDate");

                entity.Property(e => e.CessationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("cessationDate");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.IdJobTitle).HasColumnName("idJobTitle");

                entity.Property(e => e.IsPerHour).HasColumnName("isPerHour");

                entity.Property(e => e.Salary)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("salary");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.HrEmploymentContracts)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmploymentContract_Employee");

                entity.HasOne(d => d.IdJobTitleNavigation)
                    .WithMany(p => p.HrEmploymentContracts)
                    .HasForeignKey(d => d.IdJobTitle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmploymentContract_JobTitle");
            });

            modelBuilder.Entity<HrJobTitle>(entity =>
            {
                entity.HasKey(e => e.IdJobTitle)
                    .HasName("PK_JobTitle");

                entity.ToTable("hrJobTitle");

                entity.Property(e => e.IdJobTitle).HasColumnName("idJobTitle");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("abbreviation")
                    .IsFixedLength(true);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<InCampus>(entity =>
            {
                entity.HasKey(e => e.IdCampus)
                    .HasName("PK_Campus");

                entity.ToTable("inCampus");

                entity.Property(e => e.IdCampus).HasColumnName("idCampus");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("abbreviation")
                    .IsFixedLength(true);

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.AddressReference)
                    .HasMaxLength(200)
                    .HasColumnName("addressReference");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<InRoom>(entity =>
            {
                entity.HasKey(e => e.IdRoom)
                    .HasName("PK_Room");

                entity.ToTable("inRoom");

                entity.Property(e => e.IdRoom).HasColumnName("idRoom");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.IdCampus).HasColumnName("idCampus");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdCampusNavigation)
                    .WithMany(p => p.InRooms)
                    .HasForeignKey(d => d.IdCampus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_Campus");
            });

            modelBuilder.Entity<PmCountry>(entity =>
            {
                entity.HasKey(e => e.IdCountry)
                    .HasName("PK_Country");

                entity.ToTable("pmCountry");

                entity.Property(e => e.IdCountry).HasColumnName("idCountry");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.LetterCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("letterCode")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.NumericCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("numericCode")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PmDepartment>(entity =>
            {
                entity.HasKey(e => e.IdDepartment)
                    .HasName("PK_Department");

                entity.ToTable("pmDepartment");

                entity.Property(e => e.IdDepartment).HasColumnName("idDepartment");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PmDistrict>(entity =>
            {
                entity.HasKey(e => e.IdDistrict)
                    .HasName("PK_District");

                entity.ToTable("pmDistrict");

                entity.Property(e => e.IdDistrict).HasColumnName("idDistrict");

                entity.Property(e => e.IdDepartment).HasColumnName("idDepartment");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdDepartmentNavigation)
                    .WithMany(p => p.PmDistricts)
                    .HasForeignKey(d => d.IdDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_Department");
            });

            modelBuilder.Entity<PmPerson>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("PK_Person");

                entity.ToTable("pmPerson");

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.AddressReference)
                    .HasMaxLength(200)
                    .HasColumnName("addressReference");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.DocumentIdentity)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("documentIdentity");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.FatherlastName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("fatherlastName");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("firstName");

                entity.Property(e => e.IdBirthCountry).HasColumnName("idBirthCountry");

                entity.Property(e => e.IdResidentDepartment).HasColumnName("idResidentDepartment");

                entity.Property(e => e.IdResidentDistrict).HasColumnName("idResidentDistrict");

                entity.Property(e => e.IdTypeDocumentIdentity).HasColumnName("idTypeDocumentIdentity");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(100)
                    .HasColumnName("middleName");

                entity.Property(e => e.MotherlastName)
                    .HasMaxLength(150)
                    .HasColumnName("motherlastName");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("date")
                    .HasColumnName("registrationDate");

                entity.HasOne(d => d.IdBirthCountryNavigation)
                    .WithMany(p => p.PmPeople)
                    .HasForeignKey(d => d.IdBirthCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_Country");

                entity.HasOne(d => d.IdResidentDepartmentNavigation)
                    .WithMany(p => p.PmPeople)
                    .HasForeignKey(d => d.IdResidentDepartment)
                    .HasConstraintName("FK_Person_Department");

                entity.HasOne(d => d.IdResidentDistrictNavigation)
                    .WithMany(p => p.PmPeople)
                    .HasForeignKey(d => d.IdResidentDistrict)
                    .HasConstraintName("FK_Person_District");

                entity.HasOne(d => d.IdTypeDocumentIdentityNavigation)
                    .WithMany(p => p.PmPeople)
                    .HasForeignKey(d => d.IdTypeDocumentIdentity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_TypeDocumentIdentity");
            });

            modelBuilder.Entity<PmPhone>(entity =>
            {
                entity.HasKey(e => e.IdPhone)
                    .HasName("PK_Phone");

                entity.ToTable("pmPhone");

                entity.Property(e => e.IdPhone).HasColumnName("idPhone");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.Property(e => e.IdPhoneCompany).HasColumnName("idPhoneCompany");

                entity.Property(e => e.IdPhoneType).HasColumnName("idPhoneType");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsForEmergency).HasColumnName("isForEmergency");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("number");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.PmPhones)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Phone_Person");

                entity.HasOne(d => d.IdPhoneCompanyNavigation)
                    .WithMany(p => p.PmPhones)
                    .HasForeignKey(d => d.IdPhoneCompany)
                    .HasConstraintName("FK_Phone_PhoneCompany");

                entity.HasOne(d => d.IdPhoneTypeNavigation)
                    .WithMany(p => p.PmPhones)
                    .HasForeignKey(d => d.IdPhoneType)
                    .HasConstraintName("FK_Phone_PhoneType");
            });

            modelBuilder.Entity<PmPhoneCompany>(entity =>
            {
                entity.HasKey(e => e.IdPhoneCompany)
                    .HasName("PK_PhoneCompany");

                entity.ToTable("pmPhoneCompany");

                entity.Property(e => e.IdPhoneCompany).HasColumnName("idPhoneCompany");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PmPhoneType>(entity =>
            {
                entity.HasKey(e => e.IdPhoneType)
                    .HasName("PK_PhoneType");

                entity.ToTable("pmPhoneType");

                entity.Property(e => e.IdPhoneType).HasColumnName("idPhoneType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PmTypeDocumentIdentity>(entity =>
            {
                entity.HasKey(e => e.IdTypeDocumentIdentity)
                    .HasName("PK_TypeDocumentIdentity");

                entity.ToTable("pmTypeDocumentIdentity");

                entity.Property(e => e.IdTypeDocumentIdentity).HasColumnName("idTypeDocumentIdentity");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.CharacterType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("characterType")
                    .IsFixedLength(true);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.LengthType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("lengthType")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.NationalityType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("nationalityType")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<SmRelationship>(entity =>
            {
                entity.HasKey(e => e.IdRelationship)
                    .HasName("PK_Relationship");

                entity.ToTable("smRelationship");

                entity.Property(e => e.IdRelationship).HasColumnName("idRelationship");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<SmRelative>(entity =>
            {
                entity.HasKey(e => new { e.IdRelative, e.IdStudent })
                    .HasName("PK_Relative");

                entity.ToTable("smRelative");

                entity.Property(e => e.IdRelative).HasColumnName("idRelative");

                entity.Property(e => e.IdStudent)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("idStudent")
                    .IsFixedLength(true);

                entity.Property(e => e.IdRelationship).HasColumnName("idRelationship");

                entity.Property(e => e.IsGuardian).HasColumnName("isGuardian");

                entity.Property(e => e.LiveWithStudent).HasColumnName("liveWithStudent");

                entity.HasOne(d => d.IdRelationshipNavigation)
                    .WithMany(p => p.SmRelatives)
                    .HasForeignKey(d => d.IdRelationship)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Relative_Relationship");

                entity.HasOne(d => d.IdRelativeNavigation)
                    .WithMany(p => p.SmRelatives)
                    .HasForeignKey(d => d.IdRelative)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Relative_Person");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.SmRelatives)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Relative_Student");
            });

            modelBuilder.Entity<SmStudent>(entity =>
            {
                entity.HasKey(e => e.IdStudent)
                    .HasName("PK_Student");

                entity.ToTable("smStudent");

                entity.Property(e => e.IdStudent)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("idStudent")
                    .IsFixedLength(true);

                entity.Property(e => e.Allergies)
                    .HasMaxLength(200)
                    .HasColumnName("allergies");

                entity.Property(e => e.Disease)
                    .HasMaxLength(250)
                    .HasColumnName("disease");

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.OtherHealthProblem)
                    .HasMaxLength(250)
                    .HasColumnName("otherHealthProblem");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.SmStudents)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Person");
            });

            modelBuilder.Entity<SmStudentDocument>(entity =>
            {
                entity.HasKey(e => e.IdStudentDocument)
                    .HasName("PK_StudentDocument");

                entity.ToTable("smStudentDocument");

                entity.Property(e => e.IdStudentDocument).HasColumnName("idStudentDocument");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.EstimatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("estimatedDate");

                entity.Property(e => e.IdReceptionCoordinator).HasColumnName("idReceptionCoordinator");

                entity.Property(e => e.IdStudent)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("idStudent")
                    .IsFixedLength(true);

                entity.Property(e => e.IdStudentDocumentType).HasColumnName("idStudentDocumentType");

                entity.Property(e => e.ReceptionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("receptionDate");

                entity.HasOne(d => d.IdReceptionCoordinatorNavigation)
                    .WithMany(p => p.SmStudentDocuments)
                    .HasForeignKey(d => d.IdReceptionCoordinator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentDocument_Coordinator");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.SmStudentDocuments)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentDocument_Student");

                entity.HasOne(d => d.IdStudentDocumentTypeNavigation)
                    .WithMany(p => p.SmStudentDocuments)
                    .HasForeignKey(d => d.IdStudentDocumentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentDocument_StudentDocumentType");
            });

            modelBuilder.Entity<SmStudentSchoolOrigin>(entity =>
            {
                entity.HasKey(e => e.IdStudentSchoolOrigin)
                    .HasName("PK_StudentSchoolOrigin");

                entity.ToTable("smStudentSchoolOrigin");

                entity.Property(e => e.IdStudentSchoolOrigin).HasColumnName("idStudentSchoolOrigin");

                entity.Property(e => e.IdScholarStatus).HasColumnName("idScholarStatus");

                entity.Property(e => e.IdSchoolLevel).HasColumnName("idSchoolLevel");

                entity.Property(e => e.IdSchoolOrigin).HasColumnName("idSchoolOrigin");

                entity.Property(e => e.IdStudent)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("idStudent")
                    .IsFixedLength(true);

                entity.Property(e => e.Observation)
                    .HasMaxLength(200)
                    .HasColumnName("observation");

                entity.HasOne(d => d.IdScholarStatusNavigation)
                    .WithMany(p => p.SmStudentSchoolOrigins)
                    .HasForeignKey(d => d.IdScholarStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentSchoolOrigin_ScholarStatus");

                entity.HasOne(d => d.IdSchoolLevelNavigation)
                    .WithMany(p => p.SmStudentSchoolOrigins)
                    .HasForeignKey(d => d.IdSchoolLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentSchoolOrigin_SchoolLevel");

                entity.HasOne(d => d.IdSchoolOriginNavigation)
                    .WithMany(p => p.SmStudentSchoolOrigins)
                    .HasForeignKey(d => d.IdSchoolOrigin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentSchoolOrigin_SchoolOrigin");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.SmStudentSchoolOrigins)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentSchoolOrigin_Student");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
