using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Data;
using MusicAPI.Helpers;
using MusicAPI.Interfaces;
using MusicAPI.Models;
using System.Linq;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;

        public SongsController(ISongRepository songRepository, IMapper mapper)
        {
            _songRepository = songRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Song song)
        {
            var imageUrl = await FileHelper.UploadImage(song.Image);
            song.ImageUrl = imageUrl;
            var audioFileUrl = await FileHelper.UploadAudioFile(song.AudioFile);
            song.AudioUrl = audioFileUrl;
            song.UploadedDate = DateTime.Now;
            await _songRepository.AddAsync(song);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSongs(int? pageNumber, int? pageSize) 
        {
            var currentPageNumber = pageNumber ?? 1;
            var currentPageSize = pageSize ?? 5;
            var songs = await _songRepository.GetAllAsync();
            if(songs == null)
                return NotFound();
            var songResponse = _mapper.Map<IEnumerable<Song>,IEnumerable<SongResponse>>(songs);
            return Ok(songResponse.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FeaturedSongs()
        {
            var songs = await _songRepository.GetFeaturedSongs();
            if(songs == null)
                return NotFound();
            var songResponse = _mapper.Map<IEnumerable<Song>, IEnumerable<SongResponse>>(songs);
            return Ok(songResponse);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> NewSongs(int amount = 10)
        {
            var songs = await _songRepository.GetNewSongs(amount);
            if (songs == null)
                return NotFound();
            var songResponse = _mapper.Map<IEnumerable<Song>, IEnumerable<SongResponse>>(songs);
            return Ok(songResponse);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SearchSongs(string query)
        {
            var songs = await _songRepository.GetSearchSongs(query);
            if(songs == null)
                return NotFound("There are no songs similar with your request");
            var songResponse = _mapper.Map<IEnumerable<Song>, IEnumerable<SongResponse>>(songs);
            return Ok(songResponse);
        }
    }
}
