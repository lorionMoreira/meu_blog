using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_asp_net2.Application.Dtos;

namespace blog_asp_net2.Application.Contratos
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDto userUpdateDto);
    }
}