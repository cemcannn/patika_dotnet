using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.AuthorOperations.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(IMapper mapper, IBookStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public List<AuthorViewModel> Handle()
        {
            var authorList = _dbContext.Authors.OrderBy(x => x.Id).ToList();

            //Mapping
            List<AuthorViewModel> vm = _mapper.Map<List<AuthorViewModel>>(authorList);

            return vm;
        }
    }
    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string BirthDate { get; set; }
    }
}
