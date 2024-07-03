﻿using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.TagDtos;

namespace DapperProject.Services.TagServices
{
    public class TagService : ITagService
    {
        private readonly DapperContext _dapperContext;

        public TagService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<ResultTagDto>> GetAllTagAsync()
        {
            string query = "select * from TblTag";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<ResultTagDto>(query);
            return values.ToList();
        }
    }
}
