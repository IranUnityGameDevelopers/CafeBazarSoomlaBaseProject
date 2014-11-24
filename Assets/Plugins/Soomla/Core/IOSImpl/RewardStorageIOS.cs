/// Copyright (C) 2012-2014 Soomla Inc.
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///      http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.

using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace Soomla {
	
	public class RewardStorageIOS : RewardStorage {

#if UNITY_IOS && !UNITY_EDITOR
		[DllImport ("__Internal")]
		private static extern long rewardStorage_GetLastGivenTimeMillis(string rewardJson);
		[DllImport ("__Internal")]
		private static extern int rewardStorage_GetTimesGiven(string rewardJson);
		[DllImport ("__Internal")]
		private static extern void rewardStorage_SetTimesGiven(string rewardJson, 
		                                                             [MarshalAs(UnmanagedType.Bool)] bool up, 
		                                                             [MarshalAs(UnmanagedType.Bool)] bool notify);
		[DllImport ("__Internal")]
		private static extern int rewardStorage_GetLastSeqIdxGiven(string rewardJson);
		[DllImport ("__Internal")]
		private static extern void rewardStorage_SetLastSeqIdxGiven(string rewardJson, int idx);
		
		/// <summary>
		/// Get last id of given reward from a <c>SequenceReward</c>
		/// </summary>
		/// <param name="reward">to query</param>
		/// <returns>last index of sequence reward given</returns>
		override protected int _getLastSeqIdxGiven(SequenceReward seqReward) {
			string rewardJson = seqReward.toJSONObject().ToString();
			return rewardStorage_GetLastSeqIdxGiven(rewardJson);
		}
		
		/// <summary>
		/// Set last id of given reward from a <c>SequenceReward</c>
		/// </summary>
		/// <param name="reward">to set last id for</param>
		/// <param name="reward">the last id to to mark as given</param>
		override protected void _setLastSeqIdxGiven(SequenceReward seqReward, int idx) {
			string rewardJson = seqReward.toJSONObject().ToString();
			rewardStorage_SetLastSeqIdxGiven(rewardJson, idx);
		}

		override protected void _setTimesGiven(Reward reward, bool up) {
			string rewardJson = reward.toJSONObject().ToString();
			rewardStorage_SetTimesGiven(rewardJson, up, notify);
		}
		
		override protected int _getTimesGiven(Reward reward) {
			string rewardJson = reward.toJSONObject().ToString();
			int times = rewardStorage_GetTimesGiven(rewardJson);
			SoomlaUtils.LogDebug("SOOMLA/UNITY RewardStorageIOS", string.Format("reward {0} given={1}", reward.ID, times));
			return times;
		}

		override protected DateTime _getLastGivenTime(Reward reward) {
			string rewardJson = seqReward.toJSONObject().ToString();
			long lastTime = rewardStorage_GetLastGivenTimeMillis(rewardJson);
			TimeSpan time = TimeSpan.FromMilliseconds(lastTime);
			return new DateTime(time.Ticks);
		}
#endif
	}
}