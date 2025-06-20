﻿using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation;

public class MenuMutation : ObjectGraphType
{
    public MenuMutation(IMenuRepository menuRepository)
    {
        Field<MenuType>("CreateMenu")
            .Arguments(new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu" })).Resolve(context =>
            {
                return menuRepository.AddMenu(context.GetArgument<Menu>("menu"));
            });

        Field<MenuType>("UpdateMenu")
            .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" }, new QueryArgument<MenuInputType> { Name = "menu" })).Resolve(context =>
            {
                var menuId = context.GetArgument<int>("menuId");
                var menu = context.GetArgument<Menu>("menu");
                return menuRepository.UpdateMenu(menuId, menu);
            });

        Field<StringGraphType>("DeleteMenu")
            .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" })).Resolve(context =>
            {
                var menuId = context.GetArgument<int>("menuId");
                menuRepository.DeleteMenu(menuId);
                return "The menu against this Id" + menuId + "has been deleted";
            });
    }
}
