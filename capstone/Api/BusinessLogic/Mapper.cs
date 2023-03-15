using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Mapper
    {
        public static Models.Patient_Basic_Record PbMap(EntityFrameRepo.Entities.PatientBasicRecord r)
        {
            return new Models.Patient_Basic_Record()
            {
                Id = (Guid)r.Id,
                Date_Time = (DateTime)r.DateTime,
                Patient_Id = r.PatientId,
                Nurse_Id = r.NurseId,
                Bp = r.Bp,
                Heart_Rate = (int)r.HeartRate,
                SpO2 = r.SpO2

            };
        }

        public static EntityFrameRepo.Entities.PatientBasicRecord PbMap(Models.Patient_Basic_Record r)
        {
            return new EntityFrameRepo.Entities.PatientBasicRecord()
            {
                Id = r.Id,
                DateTime = r.Date_Time,
                PatientId = r.Patient_Id,
                NurseId = r.Nurse_Id,
                Bp = Validations.IsValidBP(r.Bp),
                HeartRate = r.Heart_Rate,
                SpO2 = r.SpO2
            };
        }

        public static Models.Patient_Health_Record HrMap(EntityFrameRepo.Entities.PatientHealthRecord hr)
        {
            return new Models.Patient_Health_Record()
            {
                Id = hr.Id,
                Date_Time= (DateTime)hr.DateTime,
                Patient_Id = hr.PatientId,
                Doctor_Id= hr.DoctorId,
                Conclusion = hr.Conclusion
            };
        }

        public static EntityFrameRepo.Entities.PatientHealthRecord HrMap(Models.Patient_Health_Record hr)
        {
            return new EntityFrameRepo.Entities.PatientHealthRecord()
            {
                Id = hr.Id,
                DateTime = hr.Date_Time,
                PatientId = hr.Patient_Id,
                DoctorId = hr.Doctor_Id,
                Conclusion = hr.Conclusion
            };
        }
        public static Models.Patient_Medication MrMap(EntityFrameRepo.Entities.PatientMedication mr)
        {
            return new Models.Patient_Medication()
            {
                Id = mr.Id,
                Health_Id = (Guid)mr.HealthId,
                Drugs = mr.Drug
            };
        }

        public static EntityFrameRepo.Entities.PatientMedication MrMap(Models.Patient_Medication mr)
        {
            return new EntityFrameRepo.Entities.PatientMedication()
            {
                Id = mr.Id,
                HealthId = mr.Health_Id,
                Drug = mr.Drugs
            };
        }
        public static Models.Patient_Test TMap(EntityFrameRepo.Entities.PatientTest tm)
        {
            return new Models.Patient_Test()
            {
                Id = tm.Id,
                Health_Id = (Guid)tm.HealthId,
                Test = tm.Test,
                Result = tm.Result
            };
        }
        public static EntityFrameRepo.Entities.PatientTest TMap(Models.Patient_Test tm)
        {
            return new EntityFrameRepo.Entities.PatientTest
            {
                Id = tm.Id,
                HealthId = tm.Health_Id,
                Test = tm.Test,
                Result = tm.Result
            };
        }
        public static Models.Patient_Allergy AMap(EntityFrameRepo.Entities.PatientAllergy ar)
        {
            return new Models.Patient_Allergy()
            {
                Id = ar.Id,
                Health_Id = ar.HealthId,
                Allergy = ar.Allergy
            };
        }

        public static EntityFrameRepo.Entities.PatientAllergy AMap(Models.Patient_Allergy ar)
        {
            return new EntityFrameRepo.Entities.PatientAllergy()
            {
                Id = ar.Id,
                HealthId = ar.Health_Id,
                Allergy = ar.Allergy
            };
        }

        public static IEnumerable<Models.Patient_Basic_Record> PbMap(IEnumerable<EntityFrameRepo.Entities.PatientBasicRecord> records)
        {
            return records.Select(PbMap);
        }

        public static IEnumerable<Models.Patient_Health_Record> HrMap(IEnumerable<EntityFrameRepo.Entities.PatientHealthRecord> hr)
        {
            return hr.Select(HrMap);
        }

        public static IEnumerable<Models.Patient_Medication> MrMap(IEnumerable<EntityFrameRepo.Entities.PatientMedication> mr)
        {
            return mr.Select(MrMap);
        }

        public static IEnumerable<Models.Patient_Test> TMap(IEnumerable<EntityFrameRepo.Entities.PatientTest> tm)
        {
            return tm.Select(TMap);
        }
        public static IEnumerable<Models.Patient_Allergy> AMap(IEnumerable<EntityFrameRepo.Entities.PatientAllergy> ar)
        {
            return ar.Select(AMap);
        }
    }
}
