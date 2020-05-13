using System.Collections.Generic;
using UnityEngine;


public sealed class BotController : BaseController, IExecute, IInitialization
{
    #region Fields

    private readonly int _countBot = 5;
    private readonly List<Bot> _botList = new List<Bot>();

    #endregion


    #region Methods

    public void Initialization()
    {
        EnemyBotSpawned();
        //FriendlyBotSpawned();
    }

    public void Execute()
    {
        if (!IsActive)
        {
            return;
        }

        for (var i = 0; i < _botList.Count; i++)
        {
            _botList[i].Execute();
        }
    }

    private void AddBotToList(Bot bot)
    {
        if (!_botList.Contains(bot))
        {
            _botList.Add(bot);
            bot.OnDieChange += RemoveBotList;
        }
    }

    private void RemoveBotList(Bot bot)
    {
        if (!_botList.Contains(bot))
        {
            return;
        }

        bot.OnDieChange -= RemoveBotList;
        _botList.Remove(bot);
    }

    private void EnemyBotSpawned()
    {
        for (var index = 0; index < _countBot; index++)
        {
            // Patrol.GenericPoint(ServiceLocatorMonoBehaviour.GetService<CharacterController>().transform
            // получение случайно точки воуруг нашего персонажа
            var tempBot = Object.Instantiate(ServiceLocatorMonoBehaviour.GetService<Reference>().Bot,
                Patrol.GenericPoint(ServiceLocatorMonoBehaviour.GetService<CharacterController>().transform),
                Quaternion.identity);

            tempBot.Agent.avoidancePriority = index;
            tempBot.Target = ServiceLocatorMonoBehaviour.GetService<CharacterController>().transform;
            //todo разных противников + можно как цель добавить других ботов (массив целей)
            AddBotToList(tempBot);
        }
    }

    private void FriendlyBotSpawned()
    {
        for (var index = 0; index < _countBot; index++)
        {
            var tempBot = Object.Instantiate(ServiceLocatorMonoBehaviour.GetService<Reference>().Bot,
                Patrol.GenericPoint(ServiceLocatorMonoBehaviour.GetService<CharacterController>().transform),
                Quaternion.identity);

            tempBot.Agent.avoidancePriority = index;
            tempBot.Target = ServiceLocatorMonoBehaviour.GetService<Bot>().transform;
            AddBotToList(tempBot);
        }
    }
    #endregion
}