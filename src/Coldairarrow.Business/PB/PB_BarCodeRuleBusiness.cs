﻿using Coldairarrow.Entity.PB;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.PB
{
    public class PB_BarCodeRuleBusiness : BaseBusiness<PB_BarCodeRule>, IPB_BarCodeRuleBusiness, ITransientDependency
    {
        public PB_BarCodeRuleBusiness(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<PB_BarCodeRule>> GetDataListAsync(PB_BarCodeRulePageInput input)
        {
            var q = GetIQueryable().Where(w => w.TypeId == input.TypeId);
            var where = LinqHelper.True<PB_BarCodeRule>();
            var search = input.Search;

            ////筛选
            //if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            //{
            //    var newWhere = DynamicExpressionParser.ParseLambda<PB_BarCodeRule, bool>(
            //        ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
            //    where = where.And(newWhere);
            //}
            if (!search.Type.IsNullOrEmpty())
                where = where.And(w => w.Type == search.Type);
            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<PB_BarCodeRule> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(PB_BarCodeRule data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(PB_BarCodeRule data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        #endregion

        #region 私有成员

        #endregion
    }
}