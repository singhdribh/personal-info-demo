using Microsoft.EntityFrameworkCore;
using PersonalInfomrationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalInfomrationProject.Data.Repositories
{
    public class PersonalInformationRepository : IPersonalInformationRepository
    {
        readonly ApplicationDbContext _dbContext;
        public PersonalInformationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveInfo(PersonalInformationModel request)
        {
            if (string.IsNullOrEmpty(request.Id))
            {
                _dbContext.PersonalInformationEntities.Add(new Entities.PersonalInformationEntity
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Gender = request.Gender,
                    Email = request.Email,
                    Phone = request.Phone,
                    Id = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.Now,
                    Dob = request.Dob,
                    Language = request.Language,
                    IsDeleted = false,

                });
            }
            else
            {
                var selectedRecord = await _dbContext.PersonalInformationEntities.SingleAsync(x => x.Id == request.Id);
                if (selectedRecord == null)
                    throw new Exception("No record found while updating the record");
                selectedRecord.Email = request.Email;
                selectedRecord.Phone = request.Phone;
                selectedRecord.LastName = request.LastName;
                selectedRecord.FirstName = request.FirstName;
                selectedRecord.Gender = request.Gender;
                selectedRecord.Language = request.Language;
                selectedRecord.Dob = request.Dob;
                _dbContext.PersonalInformationEntities.Update(selectedRecord);
            }

            await _dbContext.SaveChangesAsync();
        }

        public Task<List<PersonalInformationModel>> GetAllAsync()
        {
            return _dbContext.PersonalInformationEntities.Select(x => new PersonalInformationModel(x.Gender, x.Language)
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Dob = x.Dob.DateTime,
                Email = x.Email,
                Phone = x.Phone,
            }).ToListAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var selectedRecord = await _dbContext.PersonalInformationEntities.SingleAsync(x => x.Id == id);
            if (selectedRecord == null)
                throw new Exception("No record found while updating the record");

            _dbContext.PersonalInformationEntities.Remove(selectedRecord);
            await _dbContext.SaveChangesAsync();
        }

    }
}
