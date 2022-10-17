using AutoMapper;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.AuthorOperations.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }
        public GetAuthorDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AuthorViewDetailModel Handle()
        {
            var author = _dbContext.Authors.Where(x => x.Id == AuthorId).SingleOrDefault();

            if (author is null)
            {
                throw new InvalidOperationException("Yazar Bulunamadı!");
            }
            AuthorViewDetailModel vm = _mapper.Map<AuthorViewDetailModel>(author);
            return vm;
        }

    }
    public class AuthorViewDetailModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string BirthDate { get; set; }
    }
}
