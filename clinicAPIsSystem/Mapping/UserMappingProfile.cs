using AutoMapper;
using clinicAPIsSystem.DTOs.AppointmentDTOs;
using clinicAPIsSystem.DTOs.ExaminationResultDTOs;
using clinicAPIsSystem.DTOs.FinanialReportDTOs;
using clinicAPIsSystem.DTOs.MedicalRecordDTOs;
using clinicAPIsSystem.DTOs.PaymentOperationDTOs;
using clinicAPIsSystem.DTOs.PrescriptionDTOs;
using clinicAPIsSystem.DTOs.UserDTOs.AdminDTO;
using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.CleanerDTO;
using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.MedicalStaffDTO.DoctorDTO;
using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.MedicalStaffDTO.Nurse;
using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.NonMedicalStaffDTO.AccountantDTO;
// Manager
using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.NonMedicalStaffDTO.ManagerDTO;
// Receptionist
using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.NonMedicalStaffDTO.ReceptionistDTO;
using clinicAPIsSystem.DTOs.UserDTOs.PatientDTO;
using clinicAPIsSystem.DTOs.VitalSignsDTOs;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.Models.User;
using clinicAPIsSystem.Models.User.Employee;
using clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff;
using clinicAPIsSystem.Models.User.Employee.Graduated.NonMedicalStaff;


public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {

        // Doctor


        CreateMap<Doctor, DoctorDto>();
        CreateMap<CreateDoctorDto, Doctor>();
        CreateMap<UpdateDoctorDto, Doctor>();



        // Nurse


        CreateMap<Nurse, NurseDto>();
        CreateMap<CreateNurseDto, Nurse>();
        CreateMap<UpdateNurseDto, Nurse>();



        // Accountant


        CreateMap<Accountant, AccountantDto>();
        CreateMap<CreateAccountantDto, Accountant>();
        CreateMap<UpdateAccountantDto, Accountant>();



        // Receptionist


        CreateMap<Receptionist, ReceptionistDto>();
        CreateMap<CreateReceptionistDto, Receptionist>();
        CreateMap<UpdateReceptionistDto, Receptionist>();



        // Manager


        CreateMap<Manager, ManagerDto>();
        CreateMap<CreateManagerDto, Manager>();
        CreateMap<UpdateManagerDto, Manager>();



        // Cleaner


        CreateMap<Cleaner, CleanerDto>();
        CreateMap<CreateCleanerDto, Cleaner>();
        CreateMap<UpdateCleanerDto, Cleaner>();



        // Patient


        CreateMap<Patient, PatientDto>();
        CreateMap<CreatePatientDto, Patient>();
        CreateMap<UpdatePatientDto, Patient>();



        // Prescription


        CreateMap<Prescription, PrescriptionDto>();
        CreateMap<CreatePrescriptionDto, Prescription>();
        CreateMap<UpdatePrescriptionDto, Prescription>();



        // Appointment


        CreateMap<Appointment, AppointmentDto>();
        CreateMap<CreateAppointmentDto, Appointment>();
        CreateMap<UpdateAppointmentDto, Appointment>();



        // Payment Operation


        CreateMap<PaymentOperation, PaymentOperationDto>();
        CreateMap<CreatePaymentOperationDto, PaymentOperation>();



        // Medical Record


        CreateMap<MedicalRecord, MedicalRecordDto>();
        CreateMap<CreateMedicalRecordDto, MedicalRecord>();
        CreateMap<UpdateMedicalRecordDto, MedicalRecord>();



        // Admin


        CreateMap<Admin, AdminDto>();
        CreateMap<CreateAdminDto, Admin>();
        CreateMap<UpdateAdminDto, Admin>();



        // Financial Report


        CreateMap<FinancialReport, FinancialReportDto>();
        CreateMap<CreateFinancialReportDto, FinancialReport>();



        // Examination Result


        CreateMap<ExaminationResult, ExaminationResultDto>();
        CreateMap<CreateExaminationResultDto, ExaminationResult>();
        CreateMap<UpdateExaminationResultDto, ExaminationResult>();



        // Vital Signs


        CreateMap<VitalSigns, VitalSignsDto>();
        CreateMap<CreateVitalSignsDto, VitalSigns>();
        CreateMap<UpdateVitalSignsDto, VitalSigns>();
    }
}