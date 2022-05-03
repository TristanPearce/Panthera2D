using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panthera2D
{
    /// <summary>
    /// Concurrent message bus for passing data between Panthera2D applications.
    /// </summary>
    /// <typeparam name="TKey">Key used to identify messages</typeparam>
    public class MessageBus<TKey>
    {

        private ConcurrentDictionary<TKey, object> m_store;

        private ConcurrentDictionary<TKey, List<Action<object>>> m_callbacks;

        // Key, Message Content
        public event Action<TKey, object> MessagePosted;

        public MessageBus()
        {
            m_store = new ConcurrentDictionary<TKey, object>();
            m_callbacks = new ConcurrentDictionary<TKey, List<Action<object>>>();
        }

        public void Post(TKey key, object value)
        {
            lock (m_store)
            {
                m_store[key] = value;
                MessagePosted.Invoke(key, value);
            }

            lock (m_callbacks)
            {
                if (m_callbacks.ContainsKey(key))
                {
                    m_callbacks[key]?.ForEach(x => x.Invoke(value));
                }
            }
        }

        public void On(TKey key, Action<object> callback)
        {
            lock (m_callbacks)
            {

                // Add list if it doesnt exist yet
                if (!m_callbacks.ContainsKey(key))
                {
                    m_callbacks[key] = new List<Action<object>>();
                }

                // Add callback to list
                m_callbacks[key].Add(callback);
            }
        }
    }
}
