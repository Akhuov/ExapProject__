﻿using MediatR;

namespace School.Application.UseCases.Classes.Commands
{
    public class DeleteClassRoomCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
