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
    public class EquipoService : IEquipoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EquipoService(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }

        // --------------------- ** --- CRUD EQUIPO --- ** ---------------------
        // --- ---- * SEARCH * ---- ---
        // --- SEARCH BY ID ---
        public async Task<Equipo> GetById(int id)
        {
            return await _unitOfWork.EquipoRepository.GetByIdAsync(id);
        }
        // --- SEARCH ALL ---
        public async Task<IEnumerable<Equipo>> GetAll()
        {
            return await _unitOfWork.EquipoRepository.GetAllAsync();
        }

        // --- CREATE ---
        public async Task<Equipo> Create(Equipo newEquipo)
        {
            EquipoValidators validator = new();

            var validationResult = await validator.ValidateAsync(newEquipo);
            if (validationResult.IsValid)
            {
                //
                await _unitOfWork.EquipoRepository.AddAsync(newEquipo);
                await _unitOfWork.CommitAsync();
                //
            }
            else
            {
                throw new ArgumentException(validationResult.Errors[0].ErrorMessage.ToString());
            }
            //
            return newEquipo;
        }
        // --- UPDATE ---
        public async Task<Equipo> Update(int EquipoToBeUpdatedId, Equipo newEquipoValues)
        {
            EquipoActualizarValidators EquipmentValidator = new(); //instance of the "second" validator
            //
            var validationResult = await EquipmentValidator.ValidateAsync(newEquipoValues);
            //await for the async request where it looks for all the parameters to be ok
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());
            // obj to be updated
            Equipo EquipToBeUpdated = await _unitOfWork.EquipoRepository.GetByIdAsync(EquipoToBeUpdatedId);
            //
            if (EquipToBeUpdated == null)
                throw new ArgumentException("Invalid Equipo ID while updating!");

            /*
                casco
                armadura 
                arma1 
                arma2
                guanteletes 
                grebas 
            */
            //new values to updated on the object
            EquipToBeUpdated.casco = newEquipoValues.casco;
            EquipToBeUpdated.armadura = newEquipoValues.armadura;
            EquipToBeUpdated.arma1 = newEquipoValues.arma1;
            EquipToBeUpdated.arma2 = newEquipoValues.arma2;
            EquipToBeUpdated.guanteletes = newEquipoValues.guanteletes;
            EquipToBeUpdated.grebas = newEquipoValues.grebas;
            //await for the calling of the UnitOfWork
            await _unitOfWork.CommitAsync();
            //return the await call for the .GetFunction in the repository with the existing updated obj id
            return await _unitOfWork.EquipoRepository.GetByIdAsync(EquipoToBeUpdatedId);
        }

        // --- DELETE ---
        public async Task Delete(int EquipoId)
        {
            Equipo Equipo = await _unitOfWork.EquipoRepository.GetByIdAsync(EquipoId);
            if(Equipo != null)
            {
                _unitOfWork.EquipoRepository.Remove(Equipo);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new Exception(":( este equipo no existe!");
            }
        }

        // ------- METS ESPECIFICOS ------- (not done yet)
        /*
        public async Task<Equipo> Equipar(int personajeId, int objetoToAddId){}
        public async Task<Equipo> Desequipar(int personajeId, int objetoToRemoveId){}
        */

    }
}