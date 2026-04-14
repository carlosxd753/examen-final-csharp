using examen_final_csharp.DTOs;
using examen_final_csharp.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace examen_final_csharp.Services
{
    public class UserAdminService : IUserAdminService
    {
        private readonly GimnasioDbContext _context;

        public UserAdminService(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<UserCreationResultDto> CreateUserWithSocio(CreateUserWithSocioDto dto)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            await ValidateUserData(dto.UserName, dto.Email);

            var role = await GetRoleByName("SOCIO");

            var user = new User
            {
                UserName = dto.UserName,
                NormalizedUserName = dto.UserName.ToUpperInvariant(),
                Email = dto.Email,
                NormalizedEmail = dto.Email.ToUpperInvariant(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                PhoneNumber = dto.PhoneNumber,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            await _context.UserRoles.AddAsync(
                new UserRole
                {
                    UserId = user.UserId,
                    RoleId = role.RoleId,
                    AssignedAt = DateTime.UtcNow
                }
            );

            var socio = new Socio
            {
                UserId = user.UserId,
                FechaNacimiento = dto.FechaNacimiento,
                Genero = dto.Genero,
                AlturaCm = dto.AlturaCm,
                PesoKg = dto.PesoKg,
                EmergenciaNombre = dto.EmergenciaNombre,
                EmergenciaTelefono = dto.EmergenciaTelefono,
                FechaRegistro = DateOnly.FromDateTime(DateTime.UtcNow),
                IsActive = true
            };

            await _context.Socios.AddAsync(socio);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return new UserCreationResultDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Rol = role.Name,
                SocioId = socio.SocioId
            };
        }

        public async Task<UserCreationResultDto> CreateUserWithEntrenador(
            CreateUserWithEntrenadorDto dto
        )
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            await ValidateUserData(dto.UserName, dto.Email);

            var role = await GetRoleByName("ENTRENADOR");

            var user = new User
            {
                UserName = dto.UserName,
                NormalizedUserName = dto.UserName.ToUpperInvariant(),
                Email = dto.Email,
                NormalizedEmail = dto.Email.ToUpperInvariant(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                PhoneNumber = dto.PhoneNumber,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            await _context.UserRoles.AddAsync(
                new UserRole
                {
                    UserId = user.UserId,
                    RoleId = role.RoleId,
                    AssignedAt = DateTime.UtcNow
                }
            );

            var entrenador = new Entrenadore
            {
                UserId = user.UserId,
                Especialidad = dto.Especialidad,
                Certificaciones = dto.Certificaciones,
                FechaIngreso = DateOnly.FromDateTime(DateTime.UtcNow),
                IsActive = true
            };

            await _context.Entrenadores.AddAsync(entrenador);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return new UserCreationResultDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Rol = role.Name,
                EntrenadorId = entrenador.EntrenadorId
            };
        }

        private async Task ValidateUserData(string userName, string email)
        {
            var normalizedUserName = userName.ToUpperInvariant();
            var normalizedEmail = email.ToUpperInvariant();

            var userNameExists = await _context.Users.AnyAsync(
                u => u.NormalizedUserName == normalizedUserName
            );

            if (userNameExists)
            {
                throw new InvalidOperationException("el nombre de usuario ya existe");
            }

            var emailExists = await _context.Users.AnyAsync(u => u.NormalizedEmail == normalizedEmail);

            if (emailExists)
            {
                throw new InvalidOperationException("el email ya existe");
            }
        }

        private async Task<Role> GetRoleByName(string roleName)
        {
            var normalizedRoleName = roleName.ToUpperInvariant();
            var role = await _context.Roles.FirstOrDefaultAsync(
                r => r.NormalizedName == normalizedRoleName && r.IsActive
            );

            if (role == null)
            {
                throw new InvalidOperationException($"no existe el rol {roleName}");
            }

            return role;
        }
    }
}
