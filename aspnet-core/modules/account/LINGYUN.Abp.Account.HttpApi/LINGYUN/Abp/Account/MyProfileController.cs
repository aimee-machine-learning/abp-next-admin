﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Identity;

namespace LINGYUN.Abp.Account
{
    [RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
    [Area("account")]
    [ControllerName("Profile")]
    [Route("/api/account/my-profile")]
    public class MyProfileController : AbpController, IMyProfileAppService
    {
        protected IMyProfileAppService MyProfileAppService { get; }

        public MyProfileController(
            IMyProfileAppService myProfileAppService)
        {
            MyProfileAppService = myProfileAppService;
        }

        [HttpPut]
        [Route("claims")]
        public virtual async Task SetClaimAsync(ChangeUserClaimInput input)
        {
            await MyProfileAppService.SetClaimAsync(input);
        }

        [HttpGet]
        [Route("two-factor")]
        public virtual async Task<TwoFactorEnabledDto> GetTwoFactorEnabledAsync()
        {
            return await MyProfileAppService.GetTwoFactorEnabledAsync();
        }

        [HttpPut]
        [Route("change-two-factor")]
        public virtual async Task ChangeTwoFactorEnabledAsync(TwoFactorEnabledDto input)
        {
            await MyProfileAppService.ChangeTwoFactorEnabledAsync(input);
        }

        [HttpPut]
        [Route("send-phone-number-change-code")]
        public virtual async Task SendChangePhoneNumberCodeAsync(SendChangePhoneNumberCodeInput input)
        {
            await MyProfileAppService.SendChangePhoneNumberCodeAsync(input);
        }

        [HttpPut]
        [Route("change-phone-number")]
        public virtual async Task ChangePhoneNumberAsync(ChangePhoneNumberInput input)
        {
            await MyProfileAppService.ChangePhoneNumberAsync(input);
        }
    }
}