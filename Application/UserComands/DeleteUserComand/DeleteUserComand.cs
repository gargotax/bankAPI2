﻿namespace Application.UserComands.DeleteUserComand
{
    public class DeleteUserComand
    {
        public Guid Id { get; }
        public DeleteUserComand(Guid id)
        {
            Id = id;
        }
    }
}
