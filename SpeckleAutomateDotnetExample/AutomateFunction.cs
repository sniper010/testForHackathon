using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Objects;
using Speckle.Core.Api;
using Speckle.Core.Models;
using Speckle.Automate.Sdk;
using Speckle.Core.Models.Extensions;

public static class AutomateFunction
{
  public static async Task Run(AutomationContext automationContext)
  {
    Console.WriteLine("Starting execution");
    _ = typeof(ObjectsKit).Assembly; // INFO: Force objects kit to initialize

    Console.WriteLine("Receiving version");
    var commitObject = await automationContext.ReceiveVersion();

    Console.WriteLine("Received version: " + commitObject);

    Console.WriteLine("Received version: " + commitObject);
    var objects = commitObject.Flatten().Where(x => x["parameters"] != null);

    foreach (var item in objects)
    {

      Console.WriteLine($"Received object id={item.id} name={item["name"]} cat={item["category"]}");

    }

      // .Count(b => b.speckle_type == functionInputs.SpeckleTypeToCount);

    // Console.WriteLine($"Counted {count} objects");

    // if (count < functionInputs.SpeckleTypeTargetCount) {
    //   automationContext.MarkRunFailed($"Counted {count} objects where {functionInputs.SpeckleTypeTargetCount} were expected");
    //   return;
    // }

    automationContext.MarkRunSuccess($"We've got {objects} objects");
  }
}
