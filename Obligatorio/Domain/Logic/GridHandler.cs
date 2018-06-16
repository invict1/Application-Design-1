﻿using Domain.Data;
using Domain.Entities;
using Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Domain.Interface;

namespace Domain.Logic
{
    public class GridHandler
    {
        private DataStorage storage;
        private ClientHandler clientHandler;
        private IGridRepository gridRepository;

        public GridHandler()
        {
            this.storage = DataStorage.GetStorageInstance();
            this.clientHandler = new ClientHandler();
            this.gridRepository = new GridRepository();
        }

        public Grid Get(Client client)
        {
            clientHandler.NotExist(client);
            return this.gridRepository.GetGrid(client);
        }

        public void Add(Grid grid)
        {
            Validate(grid);
            this.gridRepository.AddGrid(grid); 
        }

        private void Validate(Grid grid)
        {
            DataValidation.ValidateGridName(grid.GridName);
            clientHandler.NotExist(grid.Client);
            DataValidation.ValidateHeight(grid.Height);
            DataValidation.ValidateWidth(grid.Width);
        }

        public void Delete(Grid grid)
        {
            NotExist(grid);
            this.storage.DeleteGrid(grid);
        }
        
        public void NotExist(Grid grid)
        {
            if (!this.storage.Grids.Contains(grid))
            {
                throw new ExceptionController(ExceptionMessage.WALL_NOT_EXIST);
            }
        }

        public List<Grid> GetList()
        {
            List<Grid> gridList = storage.Grids;
            IsNotEmpty(gridList);
            return gridList;
        }

        public List<Grid> GetClientGrids(Client client)
        {
            List<Grid> gridList = new List<Grid>();
            foreach(Grid grid in storage.Grids)
            {
                if (ClientGrid(client, grid)){
                    gridList.Add(grid);
                }
            }
            IsNotEmpty(gridList);
            return gridList;
        }

        private bool ClientGrid(Client client, Grid grid)
        {
            if (grid.Client.Equals(client))
                return true;
            else
                return false;
        }

        private void IsNotEmpty(List<Grid> gridList)
        {
            if (!gridList.Any())
            {
                throw new ExceptionController(ExceptionMessage.EMPTY_GRID_LIST);
            }
        }
    }

}
