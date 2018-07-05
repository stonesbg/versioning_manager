using System;
using System.Collections.Generic;
using System.Text;

namespace versioning_manager.contracts.Models
{
    public interface IVersionDetail
    {
      int Id { get; set; }

      Version Version { get; set; }

      DateTime CreatedDate { get; set; }

  }
}
