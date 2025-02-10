using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Core.Responses;
using Services.Validators;
using Core.Interfaces.Services;

namespace Services.Services
{
    public class UbicacionService : IUbicacionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UbicacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // --------------------- ** --- CRUD UBICACION --- ** ---------------------
        // --- ---- * SEARCH * ---- ---
        // --- SEARCH BY ID ---
        public async Task<Ubicacion> GetById(int id)
        {
            return await _unitOfWork.UbicacionRepository.GetByIdAsync(id);
        }
        // --- SEARCH ALL ---
        public async Task<IEnumerable<Ubicacion>> GetAll()
        {
            return await _unitOfWork.UbicacionRepository.GetAllAsync();
        }

        // --- CREATE ---
        public async Task<Ubicacion> Create(Ubicacion newUbicacion)
        {
            UbicacionValidators validator = new();

            var validationResult = await validator.ValidateAsync(newUbicacion);
            if (validationResult.IsValid)
            {
                //
                await _unitOfWork.UbicacionRepository.AddAsync(newUbicacion);
                await _unitOfWork.CommitAsync();
                //
            }
            else
            {
                throw new ArgumentException(validationResult.Errors[0].ErrorMessage.ToString());
            }
            //
            return newUbicacion;
        }
        // --- UPDATE ---
        public async Task<Ubicacion> Update(int UbicacionToBeUpdatedId, Ubicacion newUbicacionValues)
        {
            UbicacionActualizarValidators UbiValidator = new(); //instance of the "second" validator
            //
            var validationResult = await UbiValidator.ValidateAsync(newUbicacionValues);
            //await for the async request where it looks for all the parameters to be ok
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());
            // obj to be updated
            Ubicacion UbicatToBeUpdated = await _unitOfWork.UbicacionRepository.GetByIdAsync(UbicacionToBeUpdatedId);
            //
            if (UbicatToBeUpdated == null)
                throw new ArgumentException("Invalid Ubicacion ID while updating!");

            /*
                clima
                descripcion
            */
            //new values to updated on the object
            UbicatToBeUpdated.nombre = newUbicacionValues.nombre;
            UbicatToBeUpdated.descripcion = newUbicacionValues.descripcion;
            UbicatToBeUpdated.clima = newUbicacionValues.clima;
            //await for the calling of the UnitOfWork
            await _unitOfWork.CommitAsync();
            //return the await call for the .GetFunction in the repository with the existing updated obj id
            return await _unitOfWork.UbicacionRepository.GetByIdAsync(UbicacionToBeUpdatedId);
        }
        // --- DELETE ---
        public async Task Delete(int UbicacionId)
        {
            Ubicacion Ubicacion = await _unitOfWork.UbicacionRepository.GetByIdAsync(UbicacionId);
            if(Ubicacion != null)
            {
                _unitOfWork.UbicacionRepository.Remove(Ubicacion);
                await _unitOfWork.CommitAsync();
                //is this a logical or a physical remove?
            }
            else
            {
                throw new Exception(":( La ubicacion no existe!");
            }
        }

        // ------- METS ESPECIFICOS ------- (not done yet)
        //MOVER UBICACION 
        /*public async Task<Ubicacion> MoverseDeUbicacion(int ubicToBeUpdatedId, int enemigoId){
            //guardar un enemigo en una ubicacion?
            //ubicacion.descripcion to update?

        }*/
        
    }
}