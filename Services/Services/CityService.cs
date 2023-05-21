using AutoMapper;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Services.DTOs.City;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository,
                           IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CityCreateDto city) => await _cityRepository.CreateAsync(_mapper.Map<City>(city));

        public async Task DeleteAsync(int? id) => await _cityRepository.DeleteAsync(await _cityRepository.GetByIdAsync(id));

        public async Task<IEnumerable<CityDto>> GetAllAsync() => _mapper.Map<IEnumerable<CityDto>>(await _cityRepository.FindAllAsync());

        public async Task<CityDto> GetByIdAsync(int? id) => _mapper.Map<CityDto>(await _cityRepository.GetByIdAsync(id));

        public async Task UpdateAsync(int id, CityUpdateDto city)
        {
            var dbCity = await _cityRepository.GetByIdAsync(id);

            _mapper.Map(city, dbCity);

            await _cityRepository.UpdateAsync(dbCity);

        }
    }
}
