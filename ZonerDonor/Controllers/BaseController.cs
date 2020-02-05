using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZonerDonor.Controllers
{
    public abstract class BaseController : Controller
    {
        public IMapper Mapper { get; private set; }
        public   ILogger<BaseController> Logger { get; private set; }

        public BaseController(ILogger<BaseController> logger, IMapper mapper)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
