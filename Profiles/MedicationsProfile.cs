using AutoMapper;
using SmartMedDB.DTOs;
using SmartMedDB.Models;

namespace SmartMedDB.Profiles
{
    public class MedicationsProfile : Profile
    {
        public MedicationsProfile()
        {
            // AutoMapper automatically maps the object to its DTO
            CreateMap<Medication, MedicationReadDto>();
            CreateMap<MedicationWriteDto, Medication>();
        }
    }
}