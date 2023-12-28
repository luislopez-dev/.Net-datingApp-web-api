﻿/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
namespace clone1.Core.Entities;

public class Message
{
    public int Id { get; set; }
    public AppUser Sender { get; set; }
    public string SenderUsername { get; set; }
    public int SenderId { get; set; }
    public bool SenderDeleted { get; set; }
    public AppUser Recipient { get; set; }
    public string RecipientUsername { get; set; }
    public int RecipientId { get; set; }
    public bool RecipientDeleted { get; set; }
    
    public string Content { get; set; }
    
    public DateTime DateRead { get; set; }
    public DateTime MessageSent { get; set; }
}