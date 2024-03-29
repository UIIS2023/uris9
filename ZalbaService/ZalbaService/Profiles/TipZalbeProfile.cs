﻿using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;


namespace ZalbaService.Profiles
{
    public class TipZalbeProfile:Profile
    {
        public TipZalbeProfile()
        {
            CreateMap<TipZalbe, TipZalbeDto>();
            CreateMap<TipZalbeCreationDto, TipZalbe>();
            CreateMap<TipZalbe, TipZalbe>();
            CreateMap<TipZalbeDto, TipZalbe>();
        }
    }
}
