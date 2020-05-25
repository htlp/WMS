﻿using Coldairarrow.Business.PB;
using Coldairarrow.Entity.PB;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.PB
{
    [Route("/PB/[controller]/[action]")]
    public class PB_TrayMaterialController : BaseApiController
    {
        #region DI

        public PB_TrayMaterialController(IPB_TrayMaterialBusiness pB_TrayMaterialBus)
        {
            _pB_TrayMaterialBus = pB_TrayMaterialBus;
        }

        IPB_TrayMaterialBusiness _pB_TrayMaterialBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<PB_TrayMaterial>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _pB_TrayMaterialBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<PB_TrayMaterial> GetTheData(IdInputDTO input)
        {
            return await _pB_TrayMaterialBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(PB_TrayMaterial data)
        {
            //if (data.Id.IsNullOrEmpty())
            //{
            //    InitEntity(data);

            //    await _pB_TrayMaterialBus.AddDataAsync(data);
            //}
            //else
            //{
            //    await _pB_TrayMaterialBus.UpdateDataAsync(data);
            //}
            await _pB_TrayMaterialBus.AddDataAsync(data);
        }

        [HttpPost]
        public async Task DeleteData(string trayTypeId, List<string> materialIds)
        {
            await _pB_TrayMaterialBus.DeleteDataAsync(trayTypeId, materialIds);
        }

        #endregion
    }
}