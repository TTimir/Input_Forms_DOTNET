﻿using System;
using System.Collections.Generic;

namespace Input_Forms.Models;

public partial class TblStudent
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentGender { get; set; } = null!;

    public int Age { get; set; }

    public int Standard { get; set; }

    public string SchoolName { get; set; } = null!;
}
