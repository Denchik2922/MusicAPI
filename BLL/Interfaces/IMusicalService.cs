﻿using Models;
using System.Collections.Generic;

namespace BLL.Interfaces
{
	public interface IMusicalService
	{
		List<Musician> GetAllMusicians();
	}
}