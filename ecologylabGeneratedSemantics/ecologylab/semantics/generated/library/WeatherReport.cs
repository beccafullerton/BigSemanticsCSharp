//
//  WeatherReport.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/10/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.builtins;

namespace ecologylab.semantics.generated.library 
{
	/// <summary>
	/// The definition of weather report class.
	/// </summary>
	[simpl_descriptor_classes(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[simpl_inherit]
	public class WeatherReport : Document
	{
		/// <summary>
		/// The name of the city.
		/// </summary>
		[simpl_scalar]
		private MetadataString city;

		/// <summary>
		/// The weather condition of the city, like sunny or cloudy.
		/// </summary>
		[simpl_scalar]
		private MetadataString weather;

		/// <summary>
		/// The URL of the picture indicating weather condition.
		/// </summary>
		[simpl_scalar]
		private MetadataParsedURL picUrl;

		/// <summary>
		/// The temperature.
		/// </summary>
		[simpl_scalar]
		private MetadataString temperature;

		/// <summary>
		/// The humidity of the air.
		/// </summary>
		[simpl_scalar]
		private MetadataString humidity;

		/// <summary>
		/// The wind speed.
		/// </summary>
		[simpl_scalar]
		private MetadataString wind;

		/// <summary>
		/// The dew point.
		/// </summary>
		[simpl_scalar]
		private MetadataString dewPoint;

		public WeatherReport()
		{ }

		public MetadataString City
		{
			get{return city;}
			set{city = value;}
		}

		public MetadataString Weather
		{
			get{return weather;}
			set{weather = value;}
		}

		public MetadataParsedURL PicUrl
		{
			get{return picUrl;}
			set{picUrl = value;}
		}

		public MetadataString Temperature
		{
			get{return temperature;}
			set{temperature = value;}
		}

		public MetadataString Humidity
		{
			get{return humidity;}
			set{humidity = value;}
		}

		public MetadataString Wind
		{
			get{return wind;}
			set{wind = value;}
		}

		public MetadataString DewPoint
		{
			get{return dewPoint;}
			set{dewPoint = value;}
		}
	}
}