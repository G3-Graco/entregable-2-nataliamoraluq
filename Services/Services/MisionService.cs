using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
//using Core.Services;
//using Core.Responses;
using Services.Validators;
using Core.Interfaces.Services;

namespace Services.Services
{
    public class MisionService : IMisionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MisionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // --------------------- ** --- CRUD UBICACION --- ** ---------------------
        // --- ---- * SEARCH * ---- ---
        // --- SEARCH BY ID ---
        public async Task<Mision> GetById(int id)
        {
            return await _unitOfWork.MisionRepository.GetByIdAsync(id);
        }
        // --- SEARCH ALL ---
        public async Task<IEnumerable<Mision>> GetAll()
        {
            return await _unitOfWork.MisionRepository.GetAllAsync();
        }
        // --- CREATE ---
        public async Task<Mision> Create(Mision newMision)
        {
            MisionValidators validator = new();

            var validationResult = await validator.ValidateAsync(newMision);
            if (validationResult.IsValid)
            {
                //
                await _unitOfWork.MisionRepository.AddAsync(newMision);
                await _unitOfWork.CommitAsync();
                //
            }
            else
            {
                throw new ArgumentException(validationResult.Errors[0].ErrorMessage.ToString());
            }
            //
            return newMision;
        }

        // --- UPDATE ---
        public async Task<Mision> Update(int MisionToBeUpdatedId, Mision newMisionValues)
        {
            MisionActualizarValidators MisionValidator = new(); //instance of the "second" validator
            //
            var validationResult = await MisionValidator.ValidateAsync(newMisionValues);
            //await for the async request where it looks for all the parameters to be ok
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());
            // obj to be updated
            Mision MisToBeUpdated = await _unitOfWork.MisionRepository.GetByIdAsync(MisionToBeUpdatedId);
            //
            if (MisToBeUpdated == null)
                throw new ArgumentException("Invalid Mision ID while updating!");

            /*
                string nombre 
                List<string> objetivos 
                List<string> recompensas 
                char estado 
            */
            //new values to updated on the object
            MisToBeUpdated.nombre = newMisionValues.nombre;
            MisToBeUpdated.objetivos = newMisionValues.objetivos;
            MisToBeUpdated.recompensas = newMisionValues.recompensas;
            MisToBeUpdated.estado = newMisionValues.estado;
            //await for the calling of the UnitOfWork
            await _unitOfWork.CommitAsync();
            //return the await call for the .GetFunction in the repository with the existing updated obj id
            return await _unitOfWork.MisionRepository.GetByIdAsync(MisionToBeUpdatedId);
        }

        // --- DELETE ---
        public async Task Delete(int MisionId)
        {
            Mision Mision = await _unitOfWork.MisionRepository.GetByIdAsync(MisionId);
            if(Mision != null)
            {
                _unitOfWork.MisionRepository.Remove(Mision);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new Exception(":( esta mision no existe!");
            }
        }

        // ------- METS ESPECIFICOS ------- (not done yet)
        /*
        public async Task<Mision> Aceptar(){}
        public async Task<Mision> IndicarProgreso(){}
        public async Task<Mision> Completar(){}
        */
        
    }
}