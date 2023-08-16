using System.Collections.Generic;

namespace Ultils.Dtos.Contact
{
    public class UserResponseDto : BaseUserDto
    {
        public int Id { get; set; }
        public List<BaseContactDto> Contacts { get; set; }

    }
}
