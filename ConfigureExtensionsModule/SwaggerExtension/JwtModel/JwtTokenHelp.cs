﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConfigureExtensionsModule.SwaggerExtension.JwtModel
{
    public class JwtTokenHelp
    {
        /// <summary>
        /// 密钥，注意不能太短
        /// </summary>
        public static string secretKey { get; set; } = "AAAAAAAAAAAAAAAAAAAAAA";
        /// <summary>
        /// 生成JWT字符串
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <returns></returns>
        public static string GetJWT(JwtToken tokenModel)
        {
            //DateTime utc = DateTime.UtcNow;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,tokenModel.ID.ToString()),
                // 令牌颁发时间
                new Claim(JwtRegisteredClaimNames.Iat, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                 // 过期时间 100秒
                new Claim(JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddHours(5)).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Iss,"API"), // 签发者
                new Claim(JwtRegisteredClaimNames.Aud,"User") // 接收者
            };


            // 密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenHandler = new JwtSecurityTokenHandler();

            JwtSecurityToken jwt = new JwtSecurityToken(

                claims: claims,// 声明的集合
                               //expires: .AddSeconds(36), // token的有效时间
                signingCredentials: creds
                );
            var handler = new JwtSecurityTokenHandler();
            // 生成 jwt字符串
            var strJWT = handler.WriteToken(jwt);
            return strJWT;
        }

    }
}
