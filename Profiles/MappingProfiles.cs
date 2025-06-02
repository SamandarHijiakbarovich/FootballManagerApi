using AutoMapper;
using FootballManagerApi.DTOs;
using FootballManagerApi.Models;

namespace FootballManagerApi.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        // Team mappinglari
        CreateMap<Team, TeamDto>().ReverseMap();
        CreateMap<CreateTeamDto, Team>();
        CreateMap<UpdateTeamDto, Team>();

        // Player mappinglari
        CreateMap<Player, PlayerDto>().ReverseMap();
        CreateMap<CreatePlayerDto, Player>();
        CreateMap<UpdatePlayerDto, Player>();

        // Match mappinglari
        CreateMap<Match, MatchDto>().ReverseMap();
        CreateMap<CreateMatchDto, Match>();
        CreateMap<UpdateMatchDto, Match>();

        // Goal mappinglari
        CreateMap<Goal, GoalDto>().ReverseMap();
        CreateMap<CreateGoalDto, Goal>();
        CreateMap<UpdateGoalDto, Goal>();
    }
}
