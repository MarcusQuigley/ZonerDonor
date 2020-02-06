﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZonerDonor.Entities;

namespace ZonerDonor.Hubs
{
    public class ZonorHub : Hub
    {
        int connections;
        

        public async Task PublishCreatedDonation(DonationDto donation)
        {
            if (donation == null)
            {
                throw new ArgumentNullException(nameof(donation));
            }
            await Clients.All.SendAsync("ReceiveNewDonation", donation);
        }

        public override Task OnConnectedAsync()
        {
            connections += 1;
            return base.OnConnectedAsync( );
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            connections -= 1;
            return base.OnDisconnectedAsync(exception);
        }
    }
}
