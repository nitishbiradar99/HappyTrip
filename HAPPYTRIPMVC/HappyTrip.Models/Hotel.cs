﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class Hotel
    {
        [Key]
        public long HotelId { get; set; }
        [Required]
        [Display(Name = "Hotel Name")]
        public string HotelName { get; set; }
        [Required]
        [Display(Name = "Upload Photo")]
        [DataType(DataType.Upload)]
        public byte[] Photo { get; set; }
        [Required]
        [Display(Name = "Brief Discription On Hotel")]
        [DataType(DataType.MultilineText)]
        public string BriefNote { get; set; }
        public int StarRanking { get; set; }
        [Required]
        [Display(GroupName = "Address")]
        public string Address { get; set; }
        [Required]
        public int CityId { get; set; }
        public virtual City City { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string Pincode { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, MinimumLength = 10)]
        public string ContactNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string WebsiteURL { get; set; }
        public List<HotelRoom> HotelRooms { get; set; }
        //public List<HotelReview> HotelReviews { get; set; }
    }
}