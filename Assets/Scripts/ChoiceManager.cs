using System.Collections.Generic;
using UnityEngine;
public class ChoiceManager : Manager
{
    [SerializeField] private RouteVideo startRoute;
    private RouteVideo _currentRoute;
    public RouteVideo CurrentRoute => _currentRoute;

    private void Start()
    {
        _currentRoute = startRoute;
    }

    private void OnEnable()
    {
        manager.Events.OnChoiceMade += ChoiceMade;
        manager.Events.OnStartProj += FirstRoute;
    }

    private void OnDisable()
    {
        manager.Events.OnChoiceMade -= ChoiceMade;
        manager.Events.OnStartProj -= FirstRoute;
    }

    public List<RouteChoice> GetCurrentChoices()
    {
        return _currentRoute.possibilities;
    }

    private void ChoiceMade(RouteChoice choice)
    {
        _currentRoute = choice.route;
        manager.Events.OnVideoSelected?.Invoke(choice.route);
    }

    private void FirstRoute()
    {
        manager.Events.OnVideoSelected?.Invoke(startRoute);
    }
}