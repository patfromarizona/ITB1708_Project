﻿using System.ComponentModel.DataAnnotations;


namespace TeamUP.Facade {
    public abstract class BaseView {
        [Required] public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
