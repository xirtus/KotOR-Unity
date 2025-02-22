﻿using System.IO;
using UnityEngine;

namespace KotORVR
{
	public static partial class Resources
	{
		public static GFFStruct LoadGFF(string resref, ResourceType restype)
		{
			Stream stream = GetStream(resref, restype);
			if (stream == null) {
				return null;
			}

			return new GFFLoader(stream).GetRoot();
		}

		public static Character LoadCharacter(string resref)
		{
			Stream stream = GetStream(resref, ResourceType.UTC);
			if (stream == null) {
				Debug.Log("Missing placeable template: " + resref);
				return null;
			}

			return Character.Create(new GFFLoader(stream).GetRoot());
		}

		public static Placeable LoadPlaceable(string resref)
		{
			Stream stream = GetStream(resref, ResourceType.UTP);
			if (stream == null) {
				Debug.Log("Missing placeable template: " + resref);
				return null;
			}

			return Placeable.Create(new GFFLoader(stream).GetRoot());
		}

		public static Door LoadDoor(string resref)
		{
			Stream stream = GetStream(resref, ResourceType.UTD);
			if (stream == null) {
				Debug.Log("Missing door template: " + resref);
				return null;
			}

			return Door.Create(new GFFLoader(stream).GetRoot());
		}

		public static Item LoadItem(string resref)
		{
			Stream stream = GetStream(resref, ResourceType.UTI);
			if (stream == null) {
				Debug.Log("Missing item template: " + resref);
				return null;
			}

			return Item.Create(new GFFLoader(stream).GetRoot());
		}
	}
}
