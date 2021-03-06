﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CompanyName.MyMeetings.API.Configuration.Authorization;
using CompanyName.MyMeetings.Modules.Meetings.Application.Contracts;
using CompanyName.MyMeetings.Modules.Meetings.Application.Countries;
using Microsoft.AspNetCore.Mvc;

namespace CompanyName.MyMeetings.API.Modules.Meetings.Countries
{
    [Route("api/meetings/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMeetingsModule _meetingsModule;

        public CountriesController(IMeetingsModule meetingsModule)
        {
            _meetingsModule = meetingsModule;
        }

        [HttpGet("")]
        [HasPermission(MeetingsPermissions.GetMeetingGroupProposals)]
        [ProducesResponseType(typeof(List<CountryDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMeetingGroupProposals(int? page, int? perPage)
        {
            var countries = await _meetingsModule.ExecuteQueryAsync(
                new GetAllCountriesQuery());

            return Ok(countries);
        }
    }
}