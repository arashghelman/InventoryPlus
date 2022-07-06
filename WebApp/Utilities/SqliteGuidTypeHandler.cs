﻿using System;
using System.Data;
using Dapper;

namespace WebApp.Utilities
{
    public class SqliteGuidTypeHandler : SqlMapper.TypeHandler<Guid>
    {
        public SqliteGuidTypeHandler()
        {
        }

        public override Guid Parse(object value)
        {
            return new Guid((string)value);
        }

        public override void SetValue(IDbDataParameter parameter, Guid value)
        {
            parameter.Value = value.ToString();
        }
    }
}

