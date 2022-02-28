using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace saemp_backend.DBContext.Models
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
        public virtual DbSet<InInstitution> InInstitutions { get; set; }
        public virtual DbSet<InRoom> InRooms { get; set; }
        public virtual DbSet<PmCountry> PmCountries { get; set; }
        public virtual DbSet<PmDepartment> PmDepartments { get; set; }
        public virtual DbSet<PmDistrict> PmDistricts { get; set; }
        public virtual DbSet<PmPerson> PmPeople { get; set; }
        public virtual DbSet<PmPhone> PmPhones { get; set; }
        public virtual DbSet<PmPhoneCompany> PmPhoneCompanies { get; set; }
        public virtual DbSet<PmPhoneType> PmPhoneTypes { get; set; }
        public virtual DbSet<PmProvince> PmProvinces { get; set; }
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
            });

            modelBuilder.Entity<AmDiscountVersion>(entity =>
            {
                entity.HasKey(e => e.IdDiscountVersion)
                    .HasName("PK_DiscountVersion");

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
            });

            modelBuilder.Entity<AmPaymentMethod>(entity =>
            {
                entity.HasKey(e => e.IdPaymentMethod)
                    .HasName("PK_PaymentMethod");

                entity.Property(e => e.Abbreviation).IsFixedLength(true);
            });

            modelBuilder.Entity<AmPaymentReceipt>(entity =>
            {
                entity.HasKey(e => e.IdPaymentReceipt)
                    .HasName("PK_PaymentReceipt");

                entity.Property(e => e.ReceiptNumber).IsUnicode(false);

                entity.Property(e => e.SerieNumber).IsUnicode(false);

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

                entity.Property(e => e.Abbreviation).IsFixedLength(true);
            });

            modelBuilder.Entity<AmPaymentTransaction>(entity =>
            {
                entity.HasKey(e => e.IdPaymentTransaction)
                    .HasName("PK_PaymentTransaction");

                entity.Property(e => e.NumberTransaction).IsUnicode(false);

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

                entity.Property(e => e.IdPaymentTransaction).ValueGeneratedNever();

                entity.Property(e => e.IdPaymentTransactionDetail).ValueGeneratedOnAdd();

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

                entity.Property(e => e.IdStudent)
                    .IsUnicode(false)
                    .IsFixedLength(true);

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

                entity.Property(e => e.Abbreviation).IsFixedLength(true);
            });

            modelBuilder.Entity<EpScholarStatus>(entity =>
            {
                entity.HasKey(e => e.IdScholarStatus)
                    .HasName("PK_SchoolStatus");

                entity.Property(e => e.Abbreviation).IsFixedLength(true);
            });

            modelBuilder.Entity<EpSchoolLevel>(entity =>
            {
                entity.HasKey(e => e.IdSchoolLevel)
                    .HasName("PK_SchoolLevel");

                entity.Property(e => e.Abbreviation).IsFixedLength(true);

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

                entity.Property(e => e.Abbreviation).IsFixedLength(true);
            });

            modelBuilder.Entity<HrEmployee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PK_Employee");

                entity.Property(e => e.IdEmployee).ValueGeneratedNever();

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

                entity.Property(e => e.Abbreviation).IsFixedLength(true);
            });

            modelBuilder.Entity<InCampus>(entity =>
            {
                entity.HasKey(e => e.IdCampus)
                    .HasName("PK_Campus");

                entity.Property(e => e.Abbreviation).IsFixedLength(true);

                entity.HasOne(d => d.IdInstitutionNavigation)
                    .WithMany(p => p.InCampuses)
                    .HasForeignKey(d => d.IdInstitution)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Campus_Institution");
            });

            modelBuilder.Entity<InInstitution>(entity =>
            {
                entity.HasKey(e => e.IdInstitution)
                    .HasName("PK_Institution");

                entity.Property(e => e.Abbreviation).IsFixedLength(true);
            });

            modelBuilder.Entity<InRoom>(entity =>
            {
                entity.HasKey(e => e.IdRoom)
                    .HasName("PK_Room");

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

                entity.Property(e => e.LetterCode).IsFixedLength(true);

                entity.Property(e => e.NumericCode).IsFixedLength(true);
            });

            modelBuilder.Entity<PmDepartment>(entity =>
            {
                entity.HasKey(e => e.IdDepartment)
                    .HasName("PK_Department");

                entity.Property(e => e.Code)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PmDistrict>(entity =>
            {
                entity.HasKey(e => e.IdDistrict)
                    .HasName("PK_District");

                entity.Property(e => e.Ubigeo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdDepartmentNavigation)
                    .WithMany(p => p.PmDistricts)
                    .HasForeignKey(d => d.IdDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_Department");

                entity.HasOne(d => d.IdProvinceNavigation)
                    .WithMany(p => p.PmDistricts)
                    .HasForeignKey(d => d.IdProvince)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_Province");
            });

            modelBuilder.Entity<PmPerson>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("PK_Person");

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
            });

            modelBuilder.Entity<PmPhoneType>(entity =>
            {
                entity.HasKey(e => e.IdPhoneType)
                    .HasName("PK_PhoneType");
            });

            modelBuilder.Entity<PmProvince>(entity =>
            {
                entity.HasKey(e => e.IdProvince)
                    .HasName("PK_Province");

                entity.Property(e => e.Code)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdDepartmentNavigation)
                    .WithMany(p => p.PmProvinces)
                    .HasForeignKey(d => d.IdDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Province_Department");
            });

            modelBuilder.Entity<PmTypeDocumentIdentity>(entity =>
            {
                entity.HasKey(e => e.IdTypeDocumentIdentity)
                    .HasName("PK_TypeDocumentIdentity");

                entity.Property(e => e.CharacterType)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LengthType)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NationalityType)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<SmRelationship>(entity =>
            {
                entity.HasKey(e => e.IdRelationship)
                    .HasName("PK_Relationship");
            });

            modelBuilder.Entity<SmRelative>(entity =>
            {
                entity.HasKey(e => new { e.IdRelative, e.IdStudent })
                    .HasName("PK_Relative");

                entity.Property(e => e.IdStudent)
                    .IsUnicode(false)
                    .IsFixedLength(true);

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

                entity.Property(e => e.IdStudent)
                    .IsUnicode(false)
                    .IsFixedLength(true);

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

                entity.Property(e => e.IdStudent)
                    .IsUnicode(false)
                    .IsFixedLength(true);

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

                entity.Property(e => e.IdStudent)
                    .IsUnicode(false)
                    .IsFixedLength(true);

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
