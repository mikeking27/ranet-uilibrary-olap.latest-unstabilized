﻿/*   
    Copyright (C) 2009 Galaktika Corporation ZAO

    This file is a part of Ranet.UILibrary.Olap
 
    Ranet.UILibrary.Olap is a free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
      
    You should have received a copy of the GNU General Public License
    along with Ranet.UILibrary.Olap.  If not, see <http://www.gnu.org/licenses/>.
  
    If GPL v.3 is not suitable for your products or company,
    Galaktika Corp provides Ranet.UILibrary.Olap under a flexible commercial license
    designed to meet your specific usage and distribution requirements.
    If you have already obtained a commercial license from Galaktika Corp,
    you can use this file under those license terms.
*/

using System;
using System.Collections.Generic;

namespace Ranet.Olap.Mdx
{
	public sealed class MdxWhereClause : MdxObject
	{
		private MdxExpression _Expression = null;
		public MdxExpression Expression
		{
			get { return _Expression; }
			set
			{
				_Expression = value;
				_ChildTokens = null;
			}
		}
		public MdxWhereClause() { }
		public MdxWhereClause(MdxExpression Expression)
		{
			this.Expression = Expression;
		}
		public override string SelfToken
		{
			get { return "WHERE ..."; }
		}
		public static MdxToken WHERE = new MdxToken("WHERE");
		protected override void FillChilds()
		{
			_ChildTokens = new List<MdxObject>();
			_ChildTokens.Add(WHERE);
			_ChildTokens.Add(IncShift);
			_ChildTokens.Add(NewLine);
			_ChildTokens.Add(Expression);
			_ChildTokens.Add(DecShift);
		}

		public override object Clone()
		{
			if (this.Expression == null)
			{
				return new MdxWhereClause();
			}

			return new MdxWhereClause(
					(MdxExpression)this.Expression.Clone());
		}
	}
}
