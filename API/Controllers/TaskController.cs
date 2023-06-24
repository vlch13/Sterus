using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class TaskController : BaseApiController
	{
		private readonly ITaskRepository _taskRepository;
		private readonly IMapper _mapper;
		public TaskController(ITaskRepository taskRepository, IMapper mapper)
		{
			_mapper = mapper;
			_taskRepository = taskRepository;
		}

		[HttpGet]
		public async Task<ActionResult<ShiftTask>> GetTaskId(string id)
		{
			var task = await _taskRepository.GetTaskAsync(id);

			return Ok(task ?? new ShiftTask(id));
		}

		[HttpPost]
		public async Task<ActionResult<ShiftTask>> UpdateTask(ShiftTaskDto task)
		{
			var shiftTask = _mapper.Map<ShiftTaskDto, ShiftTask>(task);

			var updatedTask = await _taskRepository.UpdateTaskAsync(shiftTask);

			return Ok(updatedTask);
		}

		[HttpDelete]
		public async Task DeleteTaskAsync(string id)
		{
			await _taskRepository.DeleteTaskAsync(id);
		}
	}
}