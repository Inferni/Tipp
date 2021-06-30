using System;
using System.Collections.Generic;
using System.Linq;
using TIPP.Server.Domain;
using TIPP.Server.Services.SQLServices;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    public class MilestoneRepository : IMilestoneRepository
    {
        private IMileStoneService service;
        private IMilestoneProgressionRepository progressionRepository;
        public MilestoneRepository(tipp_DBContext context)
        {
            service = new MilestoneSQLService(context);
            progressionRepository = new MilestoneProgressionRepository(context);
        }


        public MilestoneDTO CreateMilestone(MilestoneDTO dto)
        {
            Milestone milestone = new Milestone(dto);
            Milestone milestoneAdded = service.CreateMilestone(milestone);
            MilestoneDTO milestoneAddedDTO = new MilestoneDTO(milestoneAdded);
            return milestoneAddedDTO;
        }

        public bool DeleteMilestone(MilestoneDTO dto)
        {
            Milestone milestone = new Milestone(dto);
            return service.DeleteMilestone(milestone);
        }

        public List<ColleagueMilestoneDTO> GetColleagueMilestonesByProjectID(int UserId, ProjectDTO dto)
        {
            return service.GetColleagueMilestonesByProjectID(UserId, dto);
        }

        public object GetMilestones()
        {
            return service.GetMilestones();
        }

        public List<MilestoneDTO> GetMilestonesByActivityId(MilestoneDTO dto)
        {
            List<Milestone> milestones = service.GetMilestonesByActivityID(dto);
            List<MilestoneDTO> dtos = new List<MilestoneDTO>();

            foreach (Milestone milestone in milestones)
            {
                MilestoneDTO milestoneDTO = new MilestoneDTO(milestone);
                dtos.Add(milestoneDTO);
            }
            return dtos;
        }

        public MilestoneDTO ReadMilestone(MilestoneDTO dto)
        {
            Milestone milestone = new Milestone(dto);
            return service.ReadMilestone(milestone);
        }

        public bool UpdateMilestone(MilestoneDTO dto)
        {
            Milestone milestone = new Milestone(dto);
            return service.UpdateMilestone(milestone);
        }

        public void UpdateMilestoneWithActivityId(MilestoneDTO dto, MilestoneProgressionDTO progressionDTO)
        {
            List<MilestoneDTO> milestones = GetMilestonesByActivityId(dto);
            List<MilestoneDTO> sortedMilestones = milestones.OrderByDescending(o => o.Value).ToList();
            //sortedCards = cards.OrderByDescending(o => o.Percentage).ToList();
            bool timeIsUpdated = false;
            bool workAmountsIsUpdated = false;
            decimal progressionValue = (decimal)progressionDTO.Value;

            foreach (var milestone in milestones)
            {
                switch (milestone.Type)
                {
                    case MilestoneType.Time:
                        if (!timeIsUpdated)
                        {
                            Console.WriteLine("Updating time");
                            progressionDTO.MilestoneId = milestone.Id;
                            progressionRepository.UpdateMilestoneProgression(progressionDTO);
                            timeIsUpdated = true;
                        }

                        break;
                    case MilestoneType.Amount:
                        if (!workAmountsIsUpdated)
                        {
                            Console.WriteLine("Updating WORK");
                            progressionDTO.MilestoneId = milestone.Id;
                            progressionDTO.Value = 1;
                            progressionRepository.UpdateMilestoneProgression(progressionDTO);
                            progressionDTO.Value = progressionValue;
                            workAmountsIsUpdated = true;
                        }

                        break;
                    default:
                        break;
                }

            }

            if(!timeIsUpdated)
            {
                dto.Completed = false;
                dto.Type = MilestoneType.Time;
                dto.Name = "Niet gespecificeerd aantal uren";
                MilestoneDTO newMilestoneDTO = CreateMilestone(dto);
                progressionDTO.MilestoneId = newMilestoneDTO.Id;
                progressionRepository.CreateMilestoneProgession(progressionDTO);
            }
            if(!workAmountsIsUpdated)
            {
                dto.Completed = false;
                dto.Type = MilestoneType.Amount;
                dto.Name = "Niet gespecificeerd keren gewerkt";
                MilestoneDTO newMilestoneDTO = CreateMilestone(dto);
                progressionDTO.MilestoneId = newMilestoneDTO.Id;
                progressionDTO.Value = 1;
                progressionRepository.CreateMilestoneProgession(progressionDTO);
            }

        }
    }
}
