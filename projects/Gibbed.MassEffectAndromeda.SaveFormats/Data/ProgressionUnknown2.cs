﻿/* Copyright (c) 2017 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System.Collections.Generic;
using Gibbed.MassEffectAndromeda.FileFormats;

namespace Gibbed.MassEffectAndromeda.SaveFormats.Data
{
    public class ProgressionUnknown2
    {
        #region Fields
        private int _Unknown1;
        private readonly List<ProgressionUnknown3> _Unknown2;
        #endregion

        public ProgressionUnknown2()
        {
            this._Unknown2 = new List<ProgressionUnknown3>();
        }

        #region Properties
        public int Unknown1
        {
            get { return this._Unknown1; }
            set { this._Unknown1 = value; }
        }

        public List<ProgressionUnknown3> Unknown2
        {
            get { return this._Unknown2; }
        }
        #endregion

        internal void Read(IBitReader reader)
        {
            reader.PushFrameLength(24);
            this._Unknown1 = reader.ReadInt32();
            var unknown2Count = reader.ReadUInt16();
            this._Unknown2.Clear();
            for (int i = 0; i < unknown2Count; i++)
            {
                var unknown2 = new ProgressionUnknown3();
                unknown2.Read(reader);
                this._Unknown2.Add(unknown2);
            }
            reader.PopFrameLength();
        }

        internal void Write(IBitWriter writer)
        {
            writer.PushFrameLength(24);
            writer.WriteInt32(this._Unknown1);
            writer.WriteUInt16((ushort)this._Unknown2.Count);
            foreach (var unknown2 in this._Unknown2)
            {
                unknown2.Write(writer);
            }
            writer.PopFrameLength();
        }
    }
}
