﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.GenreOperations.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        public readonly IBookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId); 
            if (genre is null)
            {
                throw new InvalidOperationException("Kitap Türü Bulunamadı.");
            }
            return _mapper.Map<GenreDetailViewModel>(genre); 
        }
    }
    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public int Name { get; set; }

    }
}

